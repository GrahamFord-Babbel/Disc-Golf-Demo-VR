using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
    {

        //public gameButtonGui;
        public Button button;

    // Code that runs on entering the state.
        public void OnTriggerExit()
        {
            //gameButtonGui = null;

        }

        // Code that runs every frame.
        public void OnTriggerEnter(Collider other)
        {
        if (other.tag == "Hand")
        {
            button.Select();
            button.OnSelect(null);
        }



        }


    }

