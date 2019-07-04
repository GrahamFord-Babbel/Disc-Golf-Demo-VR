using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionIgnore : MonoBehaviour
{
    public GameObject player1;
    

    void Start()
    {
        Physics.IgnoreCollision(player1.GetComponent<Collider>(), GetComponent<Collider>());

    }

    //IGNORE THE PLAYER
    void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("collide (name) : " + collision.collider.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            //ignore player collider
            player1 = collision.gameObject;
            Physics.IgnoreCollision(player1.GetComponent<Collider>(), GetComponent<Collider>());
        }


    }

}
