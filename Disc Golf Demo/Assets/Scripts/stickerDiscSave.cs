using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickerDiscSave : MonoBehaviour
{
    //get tansform of this sticker
    Transform stickTrans;
    public DiscBehaviors discBehaviors;


    // Start is called before the first frame update
    void Start()
    {
        stickTrans = this.gameObject.transform;

        ////so that it doesnt matter which lvl, can always have PlayerPrefs from first lvl
        //PlayerPrefs.SetFloat("driverSpeed", discBehaviors.adjustedSpeed);
        //PlayerPrefs.SetFloat("driverGlide", discBehaviors.adjustedGlide);
        //PlayerPrefs.SetFloat("driverTurnFade", discBehaviors.adjustedTurnFade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DriverDisc:SS")
        {
            
            Debug.Log("collision w sticker");
            stickTrans.SetParent(collision.gameObject.transform);
            stickTrans.localPosition = new Vector3(0,0.03f,0);
            stickTrans.localRotation = Quaternion.Euler(0,0,0);
            Rigidbody stickRb = this.GetComponent<Rigidbody>();
            Destroy(stickRb);

            PlayerPrefs.SetFloat("driverSpeed", discBehaviors.adjustedSpeed);
            PlayerPrefs.SetFloat("driverGlide", discBehaviors.adjustedGlide);
            PlayerPrefs.SetFloat("driverTurnFade", discBehaviors.adjustedTurnFade);

        }
    }
}
