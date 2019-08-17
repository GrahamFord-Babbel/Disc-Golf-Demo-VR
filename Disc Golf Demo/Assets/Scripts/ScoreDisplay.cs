using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreText = GetComponent<Text>();
        scene = SceneManager.GetActiveScene();

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

                    useCodeText.text = useCodeText.text + " " + savedSaleCodes.usedCodes[lastSaved - 1];

                    //delete if above works
                    //foreach (string i in discRespawn.savedSaleCodes.usedCodes)
                    //{
                    //    useCodeText.text =  "You've Completed the Demo!              Recieve 5 % off in-store purchase                      @Cloud9               USE CODE:" + i;
                    //}
                    discRespawn.activateCode = false;
                //}

                //if (replayButton.replayGame)
                //{
                //    useCodeText.text = useCodeText.text + " " + savedSaleCodes.usedCodes[lastSaved - 1];
                //}
                
            }

        }
        scoreText.text = "Throw: " + scoreKeeper.score;
	}
}
