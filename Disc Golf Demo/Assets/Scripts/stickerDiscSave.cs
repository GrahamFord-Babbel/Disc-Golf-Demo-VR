using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickerDiscSave : MonoBehaviour
{
    //get tansform of this sticker
    Transform stickTrans;
    public DiscBehaviors discBehaviors;
    public GameObject stickerPasted;
    public bool stickerNowPasted;
    public EventManager eventManager;



    // Start is called before the first frame update
    void Start()
    {
        stickerPasted.SetActive(false);
        stickTrans = this.gameObject.transform;

        ////so that it doesnt matter which lvl, can always have PlayerPrefs from first lvl
        //PlayerPrefs.SetFloat("driverSpeed", discBehaviors.adjustedSpeed);
        //PlayerPrefs.SetFloat("driverGlide", discBehaviors.adjustedGlide);
        //PlayerPrefs.SetFloat("driverTurnFade", discBehaviors.adjustedTurnFade);
    }

    // Update is called once per frame
    void Update()
    {
        //quick fix, need to resolve
        if (stickerNowPasted == true & eventManager.discIsThrown == true)
        {
            this.gameObject.SetActive(false);
            stickerNowPasted = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       // if (this.GetComponent<Rigidbody>().isKinematic)
       // {
            if (collision.gameObject.name == "DriverDisc:SS")
            {
            //UNFINISHED IDEA - 
                //unnecessary because below

                //stickTrans.localRotation = Quaternion.Euler(0, 0, 0);

                //disables the rigidbody sticker, and replaces it with pre-parented sticker
                //stickTrans.localPosition = new Vector3(0, 100f, 0); //bad move, now you just have an object floating in the scene randomly...but quick fix

                //stickTrans.SetParent(collision.gameObject.transform);
                //stickTrans.localPosition = new Vector3(0, 0, 0);
                //this.GetComponent<Rigidbody>().AddForce(0, 100, 0);
                stickerPasted.SetActive(true);
                stickerNowPasted = true;
                //this.gameObject.GetComponent<Collider>().enabled = false;

                //replaced by above
                //Rigidbody stickRb = this.GetComponent<Rigidbody>();
                //Destroy(stickRb);

                PlayerPrefs.SetFloat("driverSpeed", discBehaviors.adjustedSpeed);
                PlayerPrefs.SetFloat("driverGlide", discBehaviors.adjustedGlide);
                PlayerPrefs.SetFloat("driverTurnFade", discBehaviors.adjustedTurnFade);

                //condition change to pull saved flight numbers on Hole
                discBehaviors.saveStickerPlaced = true;

                Debug.Log("collision w sticker");

            }
       // }

    }
}
