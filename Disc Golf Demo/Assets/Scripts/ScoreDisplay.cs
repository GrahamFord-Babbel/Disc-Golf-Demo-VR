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

    public DiscProgressionManagerHole discRespawnHole;

    public SavedSaleCodes savedSaleCodes;

    public Text highScoreText;
    public float highScore;

    public Text thisText;

	// Use this for initialization
	void Start () {

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
        if (scene.buildIndex == 2) //should remove this condition eventually
        {
            if (discRespawnHole.activateCode == true)
            {

                savedSaleCodes = discRespawnHole.savedSaleCodes;
                    lastSaved = savedSaleCodes.usedCodes.Length;
                    print("This is last saved:" + lastSaved);

                if (scene.buildIndex == 0 || scene.buildIndex == 3)
                {
                    useCodeText.text = useCodeText.text + " " + savedSaleCodes.usedCodes[lastSaved - 1];
                    print("officially visibly printed new code");
                }
                
                //set the new high score to current score if lower than high score (lol low / high is opposite in golf)
                if (highScore > scoreKeeper.score)
                {
                    highScore = scoreKeeper.score;
                    PlayerPrefs.SetFloat("highScore", highScore);
                    Debug.Log("high score is: " + highScore);
                }

                discRespawnHole.activateCode = false;
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
        }

        PlayerPrefs.SetFloat("highScore", highScore);
    }
}
