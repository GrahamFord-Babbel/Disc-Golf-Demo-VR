using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusControllerInput : MonoBehaviour
{
    //public SteamVR_TrackedObject trackedObj;
    //public SteamVR_Controller.Device device;

    //teleporter
    private LineRenderer laser;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask; //applies to objects so that only they are interactable (layermasks)
    public float yNudgeAmount = 1f; //specific to teleportAimerObject height
    private bool isTeleporting;

    //Dash
    public float dashSpeed = 0.1f;
    private bool isDashing;
    private float lerpTime;
    private Vector3 dashStartPosition;

    //Walking
    //public Transform playerCam;
    public float movementSpeed;
    private Vector3 movementDirection;
    private bool isWalking;



    // Use this for initialization
    void Start()
    {
        //trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
        isDashing = false;
        isTeleporting = true;
        isWalking = false;

    }

    // Update is called once per frame
    void Update()
    {
        //device = SteamVR_Controller.Input((int)trackedObj.index);
        //if (isWalking)
        //{
        //    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        //    {
        //        movementDirection = playerCam.transform.forward;
        //        movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
        //        movementDirection = movementDirection * movementSpeed * Time.deltaTime;
        //        player.transform.position += movementDirection;

        //    }
        //}


        if (isDashing)
        {
            lerpTime = 20 * dashSpeed;
            player.transform.position = Vector3.Lerp(dashStartPosition, teleportLocation, lerpTime);
            if (lerpTime >= 1)
            {
                isDashing = false;
                lerpTime = 0;
            }
        }
        else if (isTeleporting)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                //Debug.Log(thisController);
                laser.gameObject.SetActive(true);
                teleportAimerObject.SetActive(true);

                laser.SetPosition(0, gameObject.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
                {
                    teleportLocation = hit.point;
                    laser.SetPosition(1, teleportLocation);
                    //aimer position
                    teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yNudgeAmount, teleportLocation.z);
                }

                else
                {
                    teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);
                    RaycastHit groundRay;
                    if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                    {
                        teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);

                    }
                    laser.SetPosition(1, transform.forward * 15 + transform.position);
                    //aimer position
                    teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yNudgeAmount, 0);
                }
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);

                player.transform.position = teleportLocation; //commented out to allow Dashing, Dashing still uses TeleportLocation code above
                //dashStartPosition = player.transform.position; //comment back in for dashing
                //isDashing = true; //comment back in for dashing
            }
        }


    }
}
