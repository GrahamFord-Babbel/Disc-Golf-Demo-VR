using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public float score;
    public Transform player;
    public Transform discA;
    public float distanceMultiplier;


    //if disc grabbed & which disc grabbed
    public HapticVibration hapticVibrationL;
    public HapticVibration hapticVibrationR;
    public bool discGrabbedScoreKeeper;

    //to see that disc has landed, reset score (or think about listing the highest score)
    public DiscRespawn discRespawn;

    //for disabling pedestal so users don't hit it with first throw
    public GameObject pedestal;
    private int pedestalInt;


    public EventManager eventManager;


    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(gameObject);
        pedestal = GameObject.Find("Pedestal");

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (eventManager.discLanded)
        {
            discGrabbedScoreKeeper = false;
        }

        if (eventManager.discIsThrown == true)
        {
            discGrabbedScoreKeeper = true;
            discA = eventManager.discThrown.transform;

            //disable pedestal
            pedestal.SetActive(false);
        }

        else if(hapticVibrationR.discGrabbed == true)
        {

            discGrabbedScoreKeeper = true;
            discA = eventManager.discThrown.transform;

            //only if first throw on each hole
            if (pedestal.activeSelf == true)
            {
                //disable pedestal
                pedestal.SetActive(false);
            }
        }

        if (discGrabbedScoreKeeper && eventManager.discLanded != true)
        {
            if (discRespawn.scene.buildIndex < 2)
            {
                score = Vector3.Distance(player.position, discA.position) * distanceMultiplier;
            }

        }
        
    }
}
