using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HapticVibration : MonoBehaviour
{
    public bool discGrabbed; //remove this and only have it on EventManager?
    //public GameObject theDiscGrabbed;
    public float releaseTimer;
    public OVRInput.Controller thisController;
    private Collider thisControllerCollider;
    //public bool discThrown;

    //reset disc Landed
    public DiscRespawn discRespawn;

    public EventManager eventManager;
    //public Rigidbody rb;

    //get "swoosh" sound effect
    public AudioSource swooshSound;

    //get disc to make sure its in han
    public Rigidbody discRbHaptic;
    public TrailRenderer discTrail;

    public Transform vrHeadSetTransform;

    //get the realtime view from Disc
    public RealtimeView realtimeViewOnHaptic;


    // Start is called before the first frame update

    void Start()
    {
        discGrabbed = false;
        discRbHaptic = eventManager.discThrown.GetComponent<Rigidbody>();
        thisControllerCollider = this.GetComponent<Collider>();
        Debug.Log("controller collider is:" + thisControllerCollider);
        discTrail = eventManager.discThrown.GetComponent<TrailRenderer>();

    }

    //delete this is slow down (only weird change lately)
    private void FixedUpdate()
    {
        if (this.GetComponent<Collider>().enabled == false)
        {
            swooshSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        

        if (releaseTimer > 25)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            releaseTimer = 0;
            discGrabbed = false;
            eventManager.discGrabbedManager = false; //remove 1
            eventManager.discIsThrown = false;
        }
       

        if (thisControllerCollider.enabled == false && discRbHaptic.isKinematic == true)
        {
            //prime disc for release vibration
            discGrabbed = true;
            eventManager.discGrabbedManager = true; //remove 1
            eventManager.discLanded = false;
            discTrail.enabled = false; //eliminate this to speed up game?

        }

        //activate vibration on release
        if(discGrabbed == true && discRbHaptic.isKinematic == false) 
        {
            eventManager.discIsThrown = true;
            discTrail.enabled = true;
            //if this game objects parent is R, string is Rtouch, else
            if (this.gameObject.transform.parent.name == "LeftControllerAnchor")
            {
                thisController = OVRInput.Controller.LTouch;
                eventManager.rightHand = false;
            }
            else
            {
                thisController = OVRInput.Controller.RTouch;
                eventManager.rightHand = true;
            }


            //set disc velocity immediately after thrown
            OVRInput.SetControllerVibration(0.35f, 0.35f, thisController);

            //necessary anymore?
            eventManager.initialDiscVelocity = ((eventManager.discThrown.GetComponent<Rigidbody>().velocity.x)/50);

            //Debug.Log("intial velocity is: " + eventManager.initialDiscVelocity);
           
            //set disc location upon throw
            eventManager.discLocationX = eventManager.discThrown.transform;

            if (eventManager.discIsThrown == true)
            {
                releaseTimer++;
                
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //find the disc picked up
        if (other.tag == "Disc")
        {
            realtimeViewOnHaptic = other.gameObject.GetComponent<RealtimeView>();
            realtimeViewOnHaptic.RequestOwnership();
            print("OWNERSHIOP REQUESTED");

            eventManager.discThrown = other.gameObject;
            //eventManager.discThrown.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //Debug.Log("velocity: " + eventManager.discThrown.GetComponent<Rigidbody>().velocity);
            //eventManager.discThrown.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
