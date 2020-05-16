using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

    public GameObject discThrown;
    public bool discIsThrown;

    //be the Main source for scripts that rely on this bool
    public bool discLanded;

    //have main source for grabbed be here
    public bool discGrabbedManager;

    public bool rightHand = true;
    public float initialDiscVelocity;
    public Transform discLocationX;
    public int nextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {

        discIsThrown = false; //THIS BREAKs FADE 11.1? was in above

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 2;
        }

    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
