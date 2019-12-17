using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiscProgressionManagerHole : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;

    //HOLE UI Components
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
        //get active scene
        scene = SceneManager.GetActiveScene();

        //disable Hole LVL components
        holeInOne.enabled = false;
        gameOverUI.SetActive(false);
        activateCode = false;
        teleportationUIDisc.SetActive(false);

        //find savedSalesCodes to print/record Codes
        savedSaleCodes = GameObject.Find("SavedSaleCodes").GetComponent<SavedSaleCodes>();

    }

    public void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if(gameOverUI.activeSelf != true)
            {
                gameOverUI.SetActive(true);
            }
            else 
            {
                gameOverUI.SetActive(false);
            }
        }
    }

    public void OnDiscCollisionPlay(Collision collision, string tag)
    {
        //rigidbody of most likely the disc
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        //keep disc on field when land, progress play
        if (tag == "Field" && collision.gameObject.tag == "Disc")
            {
                if (eventManager.discLanded == false)
                {
                    //increase throw count
                    IncrementScore();

                    //mark location of disc landed
                    discLandedLocation = rb.position;

                    // make disc glow, and active pickup column
                    teleportUI.glow.SetActive(true);

                    //enable the translucent disc infront of player - build boolean for collision on translucent disc to port (per below)
                    teleportationUIDisc.SetActive(true); 

                    //closes the loop, so function doesnt run again
                    eventManager.discLanded = true;
                }
            }

        //carry out Game Over measures
        else if (tag == "GoalScoreTrigger-300ft")
        {
            //remove velocity 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;


            //activate game over UI
            gameOverUI.SetActive(true);

            //mark boolean that game is over
            holeInOne.enabled = true;

            if (!replayButton.replayGame)
            {
                savedSaleCodes.gameOver = true;
            }

            //allows ScoreDisplay to show the generated code
            activateCode = true;

            //increase throw count
            IncrementScore();

            //save player score
            PlayerPrefs.SetFloat("Score", scoreKeeper.score);

            //Load the next scene & as "Countable" if over 60 seconds
            StartCoroutine(LoadCountableScene());
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
        SceneManager.LoadScene(0);
    }

    void IncrementScore()
    {
        scoreKeeper.score += 1;
    }
}