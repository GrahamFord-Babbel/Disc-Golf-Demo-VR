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
    public bool addForce;
    public float overTimeSpeed;

    public EventManager eventManager;

    void Start()
    {
        addForce = false; 
    }

    private void Update()
    {
       if (eventManager.discIsThrown)
        {
            addForce = true;
        }
       else if (eventManager.discLanded == true)
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

            //turn or fade - Way to eliminate REPEAT repetition below?
            //FADE increases the curve right overtime
            if (sideThrust > 0){
                discRb.AddRelativeForce(0, 0, (sideThrust + (overTimeSpeed / 2)));
            }
            //TURN increases the curve left overtime
            else if (sideThrust < 0)
            {
                    discRb.AddRelativeForce(0, 0, (sideThrust - (overTimeSpeed / 2)));
            }
            //NEITHER
            else
            {
                discRb.AddRelativeForce(0, 0, 0);
            }


        }

    }
}
