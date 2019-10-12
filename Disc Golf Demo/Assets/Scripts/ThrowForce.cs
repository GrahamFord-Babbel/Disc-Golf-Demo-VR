using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowForce : MonoBehaviour
{

    //public float thrust;
    //public float descentThrust;
    public float sideThrust;
    public Rigidbody discRb;
    public ScoreKeeper scoreKeeper;
    //public HapticVibration hapticVibration;
    public DiscRespawn discRespawn;
    public bool addForce;
    public float overTimeSpeed;

    //get factor of turn or fade
    public int turnOrFade;

    public EventManager eventManager;

    void Start()
    {
        discRb = GetComponent<Rigidbody>();
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
            overTimeSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        if (addForce)
        {
            //if side thrust had not reached 0 continue to decrease the thrust
            if(sideThrust > 0)
            {
                overTimeSpeed = overTimeSpeed + Time.deltaTime;
            }

            //right hand throw
            if (eventManager.rightHand == true)
            {
                turnOrFade = 1;
            }
            else
            {
                turnOrFade = -1;
            }
       
            //turn or fade
            discRb.AddRelativeForce(0, 0, (sideThrust + (overTimeSpeed/2)) * turnOrFade);

        }
        



        //DELETE ALL THIS WHEN SET:

        //if (addForce == true)
        //{
        //    //if disclanded is not true
        //    //Debug.Log("the rigidbody velocity is: " + rb.velocity);
        //    if (eventManager.discThrown.name != "PutterDisc")
        //    {
        //        //makes the initial speed thrown for the user seem more realistic (instead of "slow mo")
        //        if (scoreKeeper.score <= 60)
        //        {
        //            //Debug.Log("thrust added");
        //            //rb = eventManager.discThrown.GetComponent<Rigidbody>();
        //            overTimeSpeed = overTimeSpeed + Time.deltaTime;
        //            //thrust = thrust - overTimeSpeed;

        //            //if right hand
        //            if (eventManager.rightHand == true)
        //            {
        //                rb.AddRelativeForce(transform.forward * -thrust); //*eventManager.initialDiscVelocity)
        //            }


        //            //if left hand
        //            if (eventManager.rightHand == false)
        //            {
        //                rb.AddRelativeForce(transform.forward * thrust); //*eventManager.initialDiscVelocity)
        //            }

        //        }
        //    }

        //    if ( scoreKeeper.score >= 50) //rb.velocity.x >= -6.0f
        //    {
        //        //rb = eventManager.discThrown.GetComponent<Rigidbody>();


        //        //alternative - consistent curve from throw start
        //        //Vector3 sideDir = Vector3.Cross(transform.up, rb.velocity).normalized;
        //       //rb.AddRelativeForce(0, 0, sideDir * curveAmount);


        //        rb.AddRelativeForce(0,0,sideThrust);
        //        //rb.AddForce(0, -descentThrust, 0);
        //        // Debug.Log("Sidethrust added");
        //    }
        //}

    }
}
