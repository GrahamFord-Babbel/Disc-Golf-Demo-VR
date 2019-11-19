using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour {


    //is playerprefs not working because im using playerprefsx?

    public ScoreKeeper scoreKeeper;
    public Text scoreText;
    public Text usedCodesText;
    public Text useCodeText;
    public bool codesCalledFinished;

    Scene scene;

    //uses the array length to find the last code used in USED CODES
    int lastSaved;

    //find if replayed
    public ReplayButton replayButton;

    public DiscRespawn discRespawn;

    public SavedSaleCodes savedSaleCodes;

    public Text highScoreText;
    public float highScore;

    public Text thisText;

	// Use this for initialization
	void Start () {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreText = GetComponent<Text>();
        scene = SceneManager.GetActiveScene();
        highScore = PlayerPrefs.GetFloat("highScore", highScore);
        if (highScore == 0)
        {
            highScore = 12;
        }
        Debug.Log("high score was: " + highScore);

        thisText = gameObject.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (scene.buildIndex == 0 & !codesCalledFinished)
        {
            foreach (string i in savedSaleCodes.usedCodes)
            {
                usedCodesText.text = usedCodesText.text + " NEW: " + i;
            }
            codesCalledFinished = true;
        }


        //if final hole, apply the unique sales code to UI
        if (scene.buildIndex == 3) 
        {
            if (discRespawn.activateCode == true)
            {
                //get previous high score - use if above in Start doesnt work
                //PlayerPrefs.GetFloat("highScore", highScore);


                //if (!replayButton.replayGame)
                //{
                savedSaleCodes = discRespawn.savedSaleCodes;
                    lastSaved = savedSaleCodes.usedCodes.Length;
                    print("This is last saved:" + lastSaved);

                if (scene.buildIndex == 0 || scene.buildIndex == 3)
                {
                    useCodeText.text = useCodeText.text + " " + savedSaleCodes.usedCodes[lastSaved - 1];
                    print("officially visibly printed new code");
                }
                    //delete if above works
                    //foreach (string i in discRespawn.savedSaleCodes.usedCodes)
                    //{
                    //    useCodeText.text =  "You've Completed the Demo!              Recieve 5 % off in-store purchase                      @Cloud9               USE CODE:" + i;
                    //}
           
                //}

                //if (replayButton.replayGame)
                //{
                //    useCodeText.text = useCodeText.text + " " + savedSaleCodes.usedCodes[lastSaved - 1];
                //}
                
                //set the new high score to current score if lower than high score (lol low / high is opposite in golf)
                if (highScore > scoreKeeper.score)
                {
                    highScore = scoreKeeper.score;
                    PlayerPrefs.SetFloat("highScore", highScore);
                    Debug.Log("high score is: " + highScore);
                }
                //else
                //{
                //    highScoreText.text = "Today's High Score: " + highScore;
                //}

                discRespawn.activateCode = false;
            }

        }

        //only for driving range
        if (thisText == scoreText)
        {
            //change the score value to display as int
            string displayedScore = scoreKeeper.score.ToString("F0");

            scoreText.text = "Throw: " + displayedScore;
        }
        //only for practice hole
        else if (thisText == highScoreText)
        {
            highScoreText.text = "Today's High Score: " + highScore;
            Debug.Log("high score true");
        }

        PlayerPrefs.SetFloat("highScore", highScore);
    }
}
