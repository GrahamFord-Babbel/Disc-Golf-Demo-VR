using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBehaviors : MonoBehaviour
{
    //disc Flight Numbers
    public float speed;
    public float adjustedSpeed;
    public int glide;
    public int adjustedGlide;
    //turnFade is unique (two different Flight Numbers, but simply opposites); turn heads right (positive along axis), fade heads left (negative along axis)
    public int turnFade;
    public int adjustedTurnFade;

    //array and list for Speed modification
    public GameObject[] handAnchors;
    public List<OVRGrabber> ovrGrabbers;

    //get gravity alteration for Glide
    public GameObject gravityAlterationObject;
    public GravityAlteration gravityAlterationScript;

    // Start is called before the first frame update
    void Start()
    {
        //get resources-
        //find gravity alteration
        gravityAlterationScript = gravityAlterationObject.GetComponent<GravityAlteration>();

        //find all objects that have the OVRGrabber script
        handAnchors = GameObject.FindGameObjectsWithTag("HandAnchor");

        //fill list with scripts, allows for us not to use GetComponent in Update(which is expensive)
        foreach (GameObject handAnchor in handAnchors)
        {
            //add each OVRGrabber script on each HandAnchor to List
            OVRGrabber ovrGrabber = handAnchor.GetComponent<OVRGrabber>();
            if (ovrGrabber != null) ovrGrabbers.Add(ovrGrabber);
            else Debug.LogError("GameObject with tag handAnchor does not contain component OVRGrabber");
        }

    }

    // Update is called once per frame
    void Update()
    {

        //update Speed if changed
        if (speed != adjustedSpeed)
        {
                for (int i = 0; i < handAnchors.Length; i++)
                {
                    
                    ovrGrabbers[i].throwMultiplier = speed / 7;
                }
                speed = adjustedSpeed;
        }

        //update Glide if changed
        if (glide != adjustedGlide)
        {
            //readjust glide so it starts at 7 (highest), so that each change causes an inverse to actual gravityMod
            glide = 7;    

            //gravity changes inverse to the actual glide amount
            gravityAlterationScript.putterGravityMod = -(glide - adjustedGlide);
            gravityAlterationScript.gravityChangeActivated = true;

            //reset glide
            glide = adjustedGlide;
        }

    }
}
