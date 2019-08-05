using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory(ActionCategory.Input)]

    public class ButtonFunctions : FsmStateAction
    {
        public int nextSceneIndex;

        // Start is called before the first frame update
        void Start()
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }

        // Update is called once per frame
        void Update()
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}