using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class RealtimeDiscManager : MonoBehaviour
{
    private Realtime _realtime;
    public GameObject physicsDisc;
    public GameObject materialDisc;

    private void Awake()
    {
    //    // Get the Realtime component on this game object
    //    _realtime = GetComponent<Realtime>();

    //    // Notify us when Realtime successfully connects to the room
    //    _realtime.didConnectToRoom += DidConnectToRoom;

    //    //physicsDisc = GameObject.FindGameObjectWithTag("Disc");
    //}

    //private void DidConnectToRoom(Realtime realtime)
    //{
        // Instantiate the CubePlayer for this client once we've successfully connected to the room
        Realtime.Instantiate("DriverDiscSS",                 // Prefab name materialDisc = materialDisc = 
                            position: Vector3.up, //physicsDisc.transform.position,          // Spawn at disc location
                            rotation: Quaternion.identity, //rotation: physicsDisc.transform.rotation, // No rotation
                       ownedByClient: true,                // Make sure the RealtimeView on this prefab is owned by this client
            preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                         useInstance: GetComponent<Realtime>());      //realtime      // Use the instance of Realtime that fired the didConnectToRoom event.
        //materialDisc.transform.parent = physicsDisc.transform;
    }
}
