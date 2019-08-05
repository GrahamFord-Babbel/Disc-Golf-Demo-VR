using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityAlteration : MonoBehaviour
{

    public float gravityMod;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gravityMod = -1.5f;
        }
        else
        {
            gravityMod = -1.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, gravityMod, 0);
    }
}
