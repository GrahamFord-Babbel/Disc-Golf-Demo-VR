using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscGlowGrab : MonoBehaviour
{

    public GameObject retrievableDisc;
    public GameObject glow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //find the disc picked up
        if (other.tag == "Hand")
        {
            glow.SetActive(false);
            //retrievableDisc.transform.position = other.transform.position;
        }

    }


}
