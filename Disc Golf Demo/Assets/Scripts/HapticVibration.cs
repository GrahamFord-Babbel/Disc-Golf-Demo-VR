using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticVibration : MonoBehaviour
{
    public bool discGrabbed;
    //public GameObject theDiscGrabbed;
    public float releaseTimer;
    public OVRInput.Controller thisController;
    //public bool discThrown;

    //reset disc Landed
    public DiscRespawn discRespawn;

    public EventManager eventManager;
    public Rigidbody rb;

    // Start is called before the first frame update

    void Start()
    {
        discGrabbed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (releaseTimer > 25)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            releaseTimer = 0;
            discGrabbed = false;
            eventManager.discIsThrown = false;
        }
       

        if (this.GetComponent<Collider>().enabled == false)
        {
            //prime disc for release vibration
            discGrabbed = true;
            discRespawn.discLanded = false;

        }

        //activate vibration on release
        if(discGrabbed == true && this.GetComponent<Collider>().enabled == true) 
        {
            eventManager.discIsThrown = true;
            //if this game objects parent is R, string is Rtouch, else
            if (this.gameObject.transform.parent.name == "LeftControllerAnchor")
            {
                thisController = OVRInput.Controller.LTouch;
                eventManager.rightHand = false;
            }
            else
            {
                thisController = OVRInput.Controller.RTouch;
                eventManager.rightHand = true;
            }

            OVRInput.SetControllerVibration(0.35f, 0.35f, thisController);

            if(eventManager.discIsThrown == true)
            {
                releaseTimer++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //find the disc picked up
        if (other.tag == "Disc")
        {
    
            eventManager.discThrown = other.gameObject;
            //Debug.Log("velocity: " + eventManager.discThrown.GetComponent<Rigidbody>().velocity);
            //eventManager.discThrown.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
