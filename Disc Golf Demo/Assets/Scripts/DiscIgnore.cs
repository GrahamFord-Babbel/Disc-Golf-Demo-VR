using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscIgnore : MonoBehaviour
{
    //also a disc ignore in PlayerCollisionIgnore as there are times when the player
    //is holding the disc that we want objects to also ignore the disc as well as the player


    //IGNORE THE PLAYER
    void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("collide (name) : " + collision.collider.gameObject.name);
        if (collision.gameObject.tag == "Disc")
        {
            //ignore disc collider
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }


    }
}
