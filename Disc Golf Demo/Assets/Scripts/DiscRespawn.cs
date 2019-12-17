using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiscRespawn : MonoBehaviour
{
    //moved to discReturn  - can delete when finished
    public GameObject discRespawnLocation; 
    public Vector3 discOriginalLocation;

    public Vector3 discReturnLocation;
    public ScoreKeeper scoreKeeper;
    //public bool discLanded; //moved to Main location on EventManager

    //UI Components
    public Text holeInOne; //aka BASKET MADE - show GameOverUI
    public GameObject gameOverUI;
    public ReplayButton replayButton;
    public TeleportUI teleportUI;


    //teleporting to Disc Automatically components
    public CharacterController charController;
    public GameObject player1;
    public Vector3 discLandedLocation;
    public float playerFinalTeleportAdjustment;
    public GameObject teleportationUIDisc;


    //public DiscGlowGrab discGlowGrab;
    //public Rigidbody discRb;
    public GameObject disolveAnim; //some kind of particle effect that explodes to let people know you scored
    ////get discTrail
    //public HapticVibration hapticVibration;

    public bool activateCode;

    public int throwCount;

    //get end script to modify Discount Code
    public SavedSaleCodes savedSaleCodes;

    public Scene scene;
    public bool loadCountableSceneBool;

    public EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        //moved to discReturn - can delete when finished
        discOriginalLocation = discRespawnLocation.transform.position;

        holeInOne.enabled = false;
        gameOverUI.SetActive(false);
        activateCode = false;
        teleportationUIDisc.SetActive(false);

        //grab the score from previous hole
        if (scene.buildIndex == 3)
        {
            scoreKeeper.score = PlayerPrefs.GetFloat("Score", 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (loadCountableSceneBool)
        //{

        //    LoadCountableScene();
        //}

        if (scene.buildIndex == 0) //NEED to figure out how not to have script variables that effect unique scenes but are applied in all scenes
        {
            //deletes the savedSalesCodes so that no Code is collected twice for that 1 user (probably a bit drastic)
            if (replayButton.replayGame)
            {
                Destroy(savedSaleCodes.gameObject); //maybe shouldn't destroy? maybe do the same thing as when autoreloads? 
            }
        }

    }

    public void OnDiscCollision(Collision collision)
    {
        //rigidbody of most likely the disc
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        //create goal effects when disc hits goal
        if (this.tag == "Goal")
        {
            //remove velocity 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            disolveAnim.transform.position = rb.position;

            //if its the driving range, then the below wont happen so that the player can continue to throw from start position
            if (scene.buildIndex == 1)
            {
                if(this.name == "QuickPlayGoalTrigger")
                {
                    //load next scene
                    SceneManager.LoadScene(3);
                }
                else if (this.name == "FullPlayGoalTrigger")
                {
                    //load next scene
                    SceneManager.LoadScene(2);
                }

            }
                if (scene.buildIndex == 2)
                {
                //increase throw count
                IncrementScore();

                    //collect score of 1st hole - tbd
                    PlayerPrefs.SetFloat("Score", scoreKeeper.score);

                    //load next scene
                    SceneManager.LoadScene(3);
                }

                else if (scene.buildIndex == 3)
                {

                //increase throw count
                IncrementScore();
                    //save score
                    PlayerPrefs.SetFloat("Score", scoreKeeper.score);

                    collision.gameObject.SetActive(false); //or move it to another location, but likely switching to different scene at this point, so this is fine.
                    
                    //find the list with all the saved sales codes (to populate the users code)
                    savedSaleCodes = GameObject.Find("SavedSaleCodes").GetComponent<SavedSaleCodes>();

                    //activate game over UI
                    gameOverUI.SetActive(true);

                    //mark boolean that game is over
                    holeInOne.enabled = true;

                    print("DISCOUNT TEXT ACTIVATEDDDDD");

                    if (!replayButton.replayGame)
                    {
                        savedSaleCodes.gameOver = true;
                    }

                    //allows ScoreDisplay to show the generated code
                    activateCode = true;

                    //Load the next scene & as "Countable" if over 60 seconds
                    StartCoroutine(LoadCountableScene());
                    //loadCountableSceneBool = true;
                }
            
            disolveAnim.SetActive(true);

        }

        //return the disc to original position on contact with field
        if (scene.buildIndex < 2)
        {
            //add a section here that has discLanded = true, then carries out below. have another code applied to the barriers that changes this boolean, remove collision tag here

            if (collision.gameObject.tag == "Disc")
            {

                //name here for DiscReturnToPlayer(Vector3 discOriginalLocation) - this will set discOriginalLocation


                eventManager.discLanded = true;
                scoreKeeper.score = 0; //replace with a "resetScore" script - if used more than once
                //eventManager.discThrown.GetComponent<Rigidbody>().velocity = Vector3.zero;
                discReturnLocation = discOriginalLocation; //+ new Vector3(Random.Range(0, 2), 0, 0);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.position = discReturnLocation;
                //eventManager.initialDiscVelocity = 0;

                //triggers LOADNEXT SCENE - when player throws into basket
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
                if (eventManager.discLanded == false)
                {
                    if (this.name == "Field")
                    {
                        //remove velocity - does not apply to barriers 11.1
                        rb.velocity = Vector3.zero;
                    }

                    //increase throw count
                    IncrementScore();

                    //mark location of disc landed
                    discLandedLocation = rb.position;

                    if (!holeInOne.enabled)
                    {
                        // make disc glow, and active pickup column
                        teleportUI.glow.SetActive(true);
                    }

                    //TeleportPlayerOnUIDiscTouch(); //REACTIVATE THIS IF WANT TO GO BACK TO NORMAL TELEPORT (PERHAPS A/B Test) 10.2

                    //enable the translucent disc infront of player - build boolean for collision on translucent disc to port (per below)
                    teleportationUIDisc.SetActive(true); ////DEACTIVATE THIS IF WANT TO GO BACK TO NORMAL TELEPORT (PERHAPS A/B Test) 10.2

                    //closes the loop, so function doesnt run again
                    eventManager.discLanded = true;


                }
      


            }
        }



    }

    public void TeleportPlayerOnUIDiscTouch()
    {
        //disables the character controller so that it won't manipulate your teleportation
        charController.enabled = false;


        //set the right height
        discLandedLocation.y += charController.height * 0.5f;

        // TELEPORT user to disc landed location
        player1.transform.position = discLandedLocation; // + new Vector3(playerFinalTeleportAdjustment, 0, 0); //REACTIVATE the new vector3 for A/B Test 10.2


        //reenables the character controller 
        charController.enabled = true;

        teleportationUIDisc.SetActive(false);
    }

    IEnumerator LoadCountableScene()
    {
        //denotes the game was not "replayed," track codes again
        //Debug.Log("EndGameLoad, only happened once");
        yield return new WaitForSeconds(15);
        //Debug.Log("not waiting for 10 seconds");

        PlayerPrefs.SetFloat("driverSpeed", 0);
        PlayerPrefs.SetFloat("driverGlide", 0);
        PlayerPrefs.SetFloat("driverTurnFade", 0);

        replayButton.replayGame = false;
        loadCountableSceneBool = false;
        Destroy(savedSaleCodes.gameObject);
        SceneManager.LoadScene(0);
    }

    void IncrementScore()
    {
        scoreKeeper.score += 1;
    }
}
