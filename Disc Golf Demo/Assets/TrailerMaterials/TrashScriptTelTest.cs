using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScriptTelTest : MonoBehaviour
{
    //teleporting to Disc Automatically components
    public CharacterController charController;
    public GameObject player1;
    public Vector3 discLandedLocation;
    public float playerFinalTeleportAdjustment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Disc")
        {

                 charController.enabled = false;
                 //remove velocity
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;



                //CONTINUE WORKING ON THIS 8.14 OR DELETE
                discLandedLocation = collision.gameObject.GetComponent<Transform>().position;

                //ROLLERCOASTER - needs to be infinite loop (outside above boolean qualifications)
                //player1.transform.position = Vector3.MoveTowards(player1.transform.position, discLandedLocation, 1);

                //OR TELEPORT
                //set the right height
                //discLandedLocation.y += player1.height * 0.5f;

                player1.transform.position = discLandedLocation + new Vector3(playerFinalTeleportAdjustment, 0, 0);

            charController.enabled = true;






        }
    }
}
