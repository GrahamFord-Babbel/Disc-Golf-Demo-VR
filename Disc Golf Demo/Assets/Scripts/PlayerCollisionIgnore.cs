using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionIgnore : MonoBehaviour
{
    public GameObject player1;

    public GameObject disc1;
    public bool startTimer;
    public float discCollisionTimer;


    //get event manager for disc Landed
    public EventManager eventManager;


    void Start()
    {
        //this is needed
        Physics.IgnoreCollision(player1.GetComponent<Collider>(), GetComponent<Collider>());

        //Physics.IgnoreCollision(disc1.GetComponent<Collider>(), GetComponent<Collider>(),false);

        //get event manager - just assign it for now. do getcomponent when fixing that to 1 across all levels


    }
    //removed because solved by BOUNCE

    //public void Update()
    //{

    //    //if (startTimer)
    //    //{
    //    //    discCollisionTimer++;
    //    //    if(discCollisionTimer > 500)
    //    //    {
    //    //        Physics.IgnoreCollision(disc1.GetComponent<Collider>(), GetComponent<Collider>(), false);
    //    //        startTimer = false;
    //    //        discCollisionTimer = 0;
    //    //        Debug.Log("timerdisabled");
    //    //    }
    //    //}
    //}

    ////IGNORE THE PLAYER
    //void OnCollisionEnter(Collision collision)
    //{
    //    //seems this is not necessary as for player it only needs to be called once
    //    ////Debug.Log("collide (name) : " + collision.collider.gameObject.name);
    //    //if (collision.gameObject.tag == "Player")
    //    //{
    //    //    //ignore player collider
    //    //    player1 = collision.gameObject;
    //    //    Physics.IgnoreCollision(player1.GetComponent<Collider>(), GetComponent<Collider>());
    //    //}


    //    if (collision.gameObject.tag == "Disc")
    //    {
    //        //make the collider react if not held in hand, not grabbed
    //        disc1 = collision.gameObject;
    //        Physics.IgnoreCollision(disc1.GetComponent<Collider>(), GetComponent<Collider>(), false);
    //        Debug.Log("disc collides");

    //        //if disc landed is true
    //        if (eventManager.discGrabbedManager)
    //        {
    //            //ignore disc collider
    //            Physics.IgnoreCollision(disc1.GetComponent<Collider>(), GetComponent<Collider>());
    //            Debug.Log("disc ignored");
    //            startTimer = true;
    //        }
    //    }


    //}

}
