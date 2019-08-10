using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;



public class VrButtonInput : MonoBehaviour
{
    public GameObject leftPointer;
    public GameObject rightPointer;
    //public FsmObject VrController;
    int nextSceneIndex;
    //public FsmEvent sendEvent;

    public GameObject usedCodes;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

    }

    //private void OnVrInputDown()
    //{

    public bool vrDown;
    void Update()
    {


        //vrDown = false;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            //SceneManager.LoadScene(nextSceneIndex);
            //Fsm.Event(sendEvent);


            vrDown = true;
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                leftPointer.SetActive(true);
                rightPointer.SetActive(false);
            }
            else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                leftPointer.SetActive(false);
                rightPointer.SetActive(true);
            }
        }

        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            vrDown = false;

        }


    }

    void OnVrInputDown()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ActivateCodes()
    {
        usedCodes.SetActive(true);
    }

    //    void Update()
    //{ 
    //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
    //    {
    //        //SceneManager.LoadScene(nextSceneIndex);
    //        Fsm.Event(sendEvent);
    //    }
    //}
}
