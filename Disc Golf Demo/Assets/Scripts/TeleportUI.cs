using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUI : MonoBehaviour
{

    public DiscRespawn discRespawn;
    public GameObject retrievableDisc;
    public GameObject glow;

    // Start is called before the first frame update
    void Start()
    {
        glow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //teleport user bc they touched disc & attach disc to their gripped hand
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            discRespawn.TeleportPlayerOnUIDiscTouch();

            glow.SetActive(false);

            retrievableDisc.transform.position = other.transform.position + new Vector3(-0.2f,-0.3f,0);// + new Vector3(other.transform.localPosition.x + 1,0,0);

        }
    }
}
