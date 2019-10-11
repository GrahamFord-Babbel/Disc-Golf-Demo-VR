using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityAlteration : MonoBehaviour
{

    public float gravityMod;
    public PutterActivate putterActivate;
    public float putterGravityMod;
    public bool gravityChangeActivated;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gravityMod = -1.25f;
        }
        else
        {
            gravityMod = -1.25f;
        }

        //set new gravity
        Physics.gravity = new Vector3(0, gravityMod, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (putterActivate.putterGravityActivated)
        {
            gravityChangeActivated = true;
        }

        if (gravityChangeActivated)
        {
            Physics.gravity = new Vector3(0, putterGravityMod, 0);
            putterActivate.putterGravityActivated = false;
            gravityChangeActivated = false;
        }
    }
}
