using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBehaviors : MonoBehaviour
{
    //disc Flight Numbers
    public float speed;
    public float adjustedSpeed;
    public float glide;
    public float adjustedGlide;
    //turnFade is unique (two different Flight Numbers, but simply opposites); turn heads right (positive along axis), fade heads left (negative along axis)
    //for the UI turn and fade will actually manipulate the same value: turnFade (but they will seem different to the user visually)
    public float turnFade;
    public float adjustedTurnFade;
    public bool adjustmentsEnabled;

    //array and list for Speed modification
    public GameObject[] handAnchors;
    public List<OVRGrabber> ovrGrabbers;

    //get gravity alteration for Glide
    public GameObject gravityAlterationObject;
    public GravityAlteration gravityAlterationScript;

    //get ThrowForce script for Turn & Fade
    public GameObject throwDisc;
    public ThrowForce throwForce;

    // Start is called before the first frame update
    void Start()
    {


        //get resources-
        //find all objects that have the OVRGrabber script
        handAnchors = GameObject.FindGameObjectsWithTag("HandAnchor");
        
        //find gravity alteration
        gravityAlterationScript = gravityAlterationObject.GetComponent<GravityAlteration>();

        //find throwDisc & throw force
        throwDisc = GameObject.FindGameObjectWithTag("Disc");
        throwForce = throwDisc.GetComponent<ThrowForce>();

        //fill list with scripts, allows for us not to use GetComponent in Update(which is expensive)
        foreach (GameObject handAnchor in handAnchors)
        {
            //add each OVRGrabber script on each HandAnchor to List
            OVRGrabber ovrGrabber = handAnchor.GetComponent<OVRGrabber>();
            if (ovrGrabber != null) ovrGrabbers.Add(ovrGrabber);
            else Debug.LogError("GameObject with tag handAnchor does not contain component OVRGrabber");
        }

        //set disc at NORMAL
        //reset speed
        for (int i = 0; i < handAnchors.Length; i++)
        {

            ovrGrabbers[i].throwMultiplier = 12 / 4;
        }
        //reset glide
        gravityAlterationScript.putterGravityMod = -2.5f;
        gravityAlterationScript.gravityChangeActivated = true;

        //reset turnFade
        throwForce.sideThrust = 0; //THIS BREAKs FADE 11.1?

        adjustmentsEnabled = false; //THIS BREAKs FADE 11.1?

    }

    // Update is called once per frame
    void Update()
    {
        //return to ideal throw Flight Numbers
        if (adjustmentsEnabled)
        {

            //update Speed if changed
            if (speed != adjustedSpeed)
            {
                for (int i = 0; i < handAnchors.Length; i++)
                {

                    ovrGrabbers[i].throwMultiplier = adjustedSpeed / 4;
                }
                speed = adjustedSpeed;
            }

            //update Glide if changed
            if (glide != adjustedGlide)
            {
                //readjust glide so it starts at 8 (1 above highest, preventing 0 gravity), so that each change causes an inverse to actual gravityMod
                glide = 8;

                //gravity changes inverse to the actual glide amount
                gravityAlterationScript.putterGravityMod = -(glide - adjustedGlide);
                gravityAlterationScript.gravityChangeActivated = true;

                //reset glide
                glide = adjustedGlide;
            }

            //Update Fade/Turn if changed
            if (turnFade != adjustedTurnFade)
            {
                throwForce.sideThrust = adjustedTurnFade;

                turnFade = adjustedTurnFade;
            }

        }
        

    }

    //HOW TO ELIMIATE BELOW & ABOVE REPETITION - C# Delegate?

    //so that the Slider can find this script and adjust the value
    public void OnSliderValueChangedSpeed(float value)
    {
        adjustedSpeed = value;
    }

    //specifically for glide
    public void OnSliderValueChangedGlide(float value)
    {
        adjustedGlide = value;
    }

    public void OnSliderValueChangedTurnFade(float value)
    {
        adjustedTurnFade = value;
    }

    public void OnSliderValueChangedEnabled(bool value)
    {
        adjustmentsEnabled = value;

        if (!adjustmentsEnabled)
        {
            //reset speed
            for (int i = 0; i < handAnchors.Length; i++)
            {

                ovrGrabbers[i].throwMultiplier = 11 / 4;
            }

            //reset glide
            gravityAlterationScript.putterGravityMod = -2.5f;
            gravityAlterationScript.gravityChangeActivated = true;

            //reset turnFade
            throwForce.sideThrust = 0;


        }

    }
}
