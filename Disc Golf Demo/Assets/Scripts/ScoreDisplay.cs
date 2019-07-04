using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public ScoreKeeper scoreKeeper;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Farthest Throw: " + scoreKeeper.score;
	}
}
