using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRaycast : MonoBehaviour
{
    private LineRenderer lineRend;
    //private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponentInChildren<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        lineRend.SetPosition(0, gameObject.transform.position);

        lineRend.SetPosition(1, transform.TransformDirection(Vector3.forward) * 50);// NEW update this in all
        RaycastHit hit;
    }
}
