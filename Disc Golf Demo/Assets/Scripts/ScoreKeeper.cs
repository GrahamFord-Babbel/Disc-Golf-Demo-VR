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


    public EventManager eventManager;


    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hapticVibrationL.discGrabbed == true)
        {
            discGrabbedScoreKeeper = true;
            discA = eventManager.discThrown.transform;
        }

        else if(hapticVibrationR.discGrabbed == true)
        {
            discGrabbedScoreKeeper = true;
            discA = eventManager.discThrown.transform;
        }

        if (discGrabbedScoreKeeper && discRespawn.discLanded != true)
        {
            score = Vector3.Distance(player.position, discA.position) * distanceMultiplier;

            if (discRespawn.discLanded)
            {
                discGrabbedScoreKeeper = false;
            }
        }
    }
}
