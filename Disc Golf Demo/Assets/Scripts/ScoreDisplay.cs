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
        PlayerPrefs.GetFloat("highScore", highScore);
        if (highScore == 0)
        {
            highScore = 8;
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

        if (scene.buildIndex == 2)
        {
            if (discRespawn.activateCode == true)
            {

                //if (!replayButton.replayGame)
                //{
                    savedSaleCodes = discRespawn.savedSaleCodes;
                    lastSaved = savedSaleCodes.usedCodes.Length;
                    print("This is last saved:" + lastSaved);

                if (scene.buildIndex == 0)
                {
                    useCodeText.text = useCodeText.text + " " + savedSaleCodes.usedCodes[lastSaved - 1];
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

        if (thisText == scoreText)
        {
            scoreText.text = "Throw: " + scoreKeeper.score;
        }
        else if (thisText == highScoreText)
        {
            highScoreText.text = "Today's High Score: " + highScore;
            Debug.Log("high schoo true");
        }

        PlayerPrefs.SetFloat("highScore", highScore);
    }
}
