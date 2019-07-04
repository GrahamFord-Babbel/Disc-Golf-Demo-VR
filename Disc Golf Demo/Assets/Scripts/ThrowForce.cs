using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowForce : MonoBehaviour
{

    public float thrust;
    public float decentThrust;
    public float sideThrust;
    public Rigidbody rb;
    public ScoreKeeper scoreKeeper;
    //public HapticVibration hapticVibration;
    public DiscRespawn discRespawn;
    public bool addForce;

    public EventManager eventManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       if (eventManager.discIsThrown)
        {
            addForce = true;
        }
       else if (discRespawn.discLanded == true)
        {
            addForce = false;
        }
    }

    void FixedUpdate()
    {
        if (addForce == true)
        {
            //if disclanded is not true
            //Debug.Log("the rigidbody velocity is: " + rb.velocity);
            if (eventManager.discThrown.name != "PutterDisc")
            {
                //makes the initial speed thrown for the user seem more realistic (instead of "slow mo")
                if (scoreKeeper.score <= 60)
                {
                    //Debug.Log("thrust added");
                    rb = eventManager.discThrown.GetComponent<Rigidbody>();

                    //if right hand
                    if (eventManager.rightHand == true)
                    {
                        rb.AddRelativeForce(transform.forward * -thrust);
                    }


                    //if left hand
                    if (eventManager.rightHand == false)
                    {
                        rb.AddRelativeForce(transform.forward * thrust);
                    }

                }
            }

            if ( scoreKeeper.score >= 50) //rb.velocity.x >= -6.0f
            {
                //rb = eventManager.discThrown.GetComponent<Rigidbody>();
                rb.AddRelativeForce(0,0,sideThrust);
                rb.AddForce(0, -decentThrust, 0);
                // Debug.Log("Sidethrust added");
            }
        }

    }
}
