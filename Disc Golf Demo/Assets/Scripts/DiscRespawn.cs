using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiscRespawn : MonoBehaviour
{
    public GameObject discRespawnLocation;
    public Vector3 discOriginalLocation;
    public Vector3 discReturnLocation;
    public Text holeInOne;
    public ScoreKeeper scoreKeeper;
    public bool discLanded;

    public DiscGlowGrab discGlowGrab;
    //public Rigidbody discRb;
    public GameObject disolveAnim; //some kind of particle effect that explodes to let people know you scored
    ////get discTrail
    //public HapticVibration hapticVibration;

    public bool activateCode;

    public int throwCount;

    //get end script to modify Discount Code
    public SavedSaleCodes savedSaleCodes;

    public Scene scene;

    public EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        discOriginalLocation = discRespawnLocation.transform.position;
        holeInOne.enabled = false;
        activateCode = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //create goal effects when disc hits goal
        if (this.tag == "Goal")
        {
            //remove velocity
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            disolveAnim.transform.position = collision.gameObject.transform.position;

            //if its the driving range, then the below wont happen so that the player can continue to throw from start position
            if (scene.buildIndex > 1)
            {
                collision.gameObject.SetActive(false); //or move it to another location, but likely switching to different scene at this point, so this is fine.
                //holeInOne.enabled = true;
                savedSaleCodes = GameObject.Find("SavedSaleCodes").GetComponent<SavedSaleCodes>();
                holeInOne.enabled = true;
                print("DISCOUT TEXT ACTIVATEDDDDD");
                savedSaleCodes.gameOver = true;
                activateCode = true;
            }
            disolveAnim.SetActive(true);

        }

        //return the disc to original position on contact with field
        if (scene.buildIndex < 2)
        {
            if (collision.gameObject.tag == "Disc")
            {
            discLanded = true;
            scoreKeeper.score = 0;
            //eventManager.discThrown.GetComponent<Rigidbody>().velocity = Vector3.zero;
            discReturnLocation = discOriginalLocation; //+ new Vector3(Random.Range(0, 2), 0, 0);
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.position = discReturnLocation;
            //eventManager.initialDiscVelocity = 0;

            if (this.gameObject.name == "GoalScoreTrigger-300ft")
                {
                    holeInOne.enabled = true;
                }

                

            }
        }
        //keep disc on field when land
        else if (scene.buildIndex > 1)
        {
            if (collision.gameObject.tag == "Disc")
            {
                if (discLanded == false)
                {
                    //remove velocity
                    collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;


                    //increase throw count
                    scoreKeeper.score += 1;


                    if (!holeInOne.enabled)
                        {
                        // make disc glow, and active pickup column
                        discGlowGrab.glow.SetActive(true);
                    }




                    discLanded = true;
                }
      


            }
        }

    }
}
