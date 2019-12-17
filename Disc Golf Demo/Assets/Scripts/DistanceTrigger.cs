using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{

    public HapticVibration hapticVibrationL;
    public HapticVibration hapticVibrationR;
    public Color originalColor;
    //public Vector3 originalPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = this.GetComponent<Renderer>().material.color;
        //originalPlayerPosition = originalPlayerPosition.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //if refresh true, turn this back to white
        if (hapticVibrationL.discGrabbed == true || hapticVibrationR.discGrabbed == true)
        {
            this.GetComponent<Renderer>().material.color = originalColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Disc")
        {
            //update pillar to "reached" material
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        //if (other.tag == "Player")
        //{
        //    other.gameObject.transform.position = originalPlayerPosition;
        //}
    }
}
