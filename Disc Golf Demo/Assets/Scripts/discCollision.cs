using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discCollision : MonoBehaviour
{
    public DiscRespawnManagerDrivingRange discRespawnDR;
    public DiscProgressionManagerHole discRespawnHole;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if respawn lvl1 (driving range) manager exists
        if(discRespawnDR != null)
        {
            discRespawnDR.OnDiscCollisionReturn(collision, this.tag);
        }
        //do the same for lvl2 (Hole) discRespawn manager
        if (discRespawnHole != null)
        {
            discRespawnHole.OnDiscCollisionPlay(collision, this.name);
        }
    }
}
