using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiscRespawnManagerDrivingRange : MonoBehaviour
{
    //UI Restart Mechanics
    public GameObject gameOverUI;

    //disc returnlocations
    public GameObject discRespawnLocation;
    public Vector3 discOriginalLocation;
    public Vector3 discReturnLocation;

    //driving range distance 
    public ScoreKeeper scoreKeeper;
    public Vector3 discLandedLocation;
    public int throwCount;

    //savedSalesCodebool
    public bool activateCode;

    //scene game state
    public Scene scene;
    public bool loadCountableSceneBool;
    public EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        gameOverUI.SetActive(false);
        discOriginalLocation = discRespawnLocation.transform.position;

    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (gameOverUI.activeSelf != true)
            {
                gameOverUI.SetActive(true);
            }
            else
            {
                gameOverUI.SetActive(false);
            }
        }
    }
    public void OnDiscCollisionReturn(Collision collision, string tag)
    {
        //rigidbody of most likely the disc
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        //load Hole
        if (tag == "Goal")
        {
            //remove velocity 
            rb.velocity = Vector3.zero; //PLACE OUTSIDE OF IF?
            rb.angularVelocity = Vector3.zero;
            SceneManager.LoadScene(2);
        }

        //return disc to original driving range position
        else if (collision.gameObject.tag == "Disc")
        {    
                eventManager.discLanded = true;
                scoreKeeper.score = 0; //replace with a "resetScore" script - if used more than once
                discReturnLocation = discOriginalLocation; 
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.position = discReturnLocation;
        }
    }

    void IncrementScore()
    {
        scoreKeeper.score += 1;
    }
}