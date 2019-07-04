using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAlteration : MonoBehaviour
{

    public float gravityMod = -0.5F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, gravityMod, 0);
    }
}
