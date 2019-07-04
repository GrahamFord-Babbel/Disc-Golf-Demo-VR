using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscRespawn : MonoBehaviour
{
    public GameObject discRespawnLocation;
    public Vector3 discOriginalLocation;
    public Vector3 discReturnLocation;
    public Text holeInOne;
    public ScoreKeeper scoreKeeper;
    public bool discLanded;

    public EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        discOriginalLocation = discRespawnLocation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Disc")
        {
            //eventManager.discThrown.GetComponent<Rigidbody>().velocity = Vector3.zero;
            discReturnLocation = discOriginalLocation + new Vector3(Random.Range(0,2), 0, 0);
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.position = discReturnLocation;

            if (this.gameObject.name == "GoalScoreTrigger-300ft")
            {
                holeInOne.enabled = true;
            }

            discLanded = true;
            scoreKeeper.score = 0;

        }
    }
}
