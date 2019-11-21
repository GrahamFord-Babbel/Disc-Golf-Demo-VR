using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
{

    //public gameButtonGui;
    public Button button;
    public EventManager eventManager;
    public bool replayGame;

    // once clicked, transition
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand") 
        {
                button.Select();

            //not sure what this would be for, but forums use it
            //button.OnSelect(null);

            PlayerPrefs.SetFloat("driverSpeed", 0);
            PlayerPrefs.SetFloat("driverGlide", 0);
            PlayerPrefs.SetFloat("driverTurnFade", 0);

            //mark as a "replayable" version
            replayGame = true;



                yield return new WaitForSeconds(1);
                eventManager.LoadNextScene();
            
            //other wise teleport user bc they touched disc & attach disc to their gripped hand
        }    

    }

    ////use this if you want to unhighlight?
    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Hand")
    //    {

    //        //START WORKING HERE 8.16

    //        eventManager.LoadNextScene();

    //        //unsure what this really does, deselects the object? Don't see.
    //        //EventSystem.current.SetSelectedGameObject(null);

    //        //  button.Select();
    //        //button.OnSelect(normal);
    //    }
    //}
}
