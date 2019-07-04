using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscIgnore : MonoBehaviour
{
    // Start is called before the first frame update


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
