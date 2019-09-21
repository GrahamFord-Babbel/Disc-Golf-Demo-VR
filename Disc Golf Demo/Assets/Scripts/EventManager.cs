using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

    public GameObject discThrown;
    public bool discIsThrown = false;
    public bool rightHand = true;
    public float initialDiscVelocity;
    public Transform discLocationX;
    int nextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 3;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
