using UnityEngine;
using Normal.Realtime;

namespace Normal.Realtime.Examples {
    public class CubePlayerManager : MonoBehaviour {
        private Realtime _realtime;
        public GameObject physicsDisc;
        public GameObject materialDisc;

        private void Awake() {
            // Get the Realtime component on this game object
            _realtime = GetComponent<Realtime>();

            // Notify us when Realtime successfully connects to the room
            _realtime.didConnectToRoom += DidConnectToRoom;

            //physicsDisc = GameObject.FindGameObjectWithTag("Disc");
        }

        private void DidConnectToRoom(Realtime realtime) {
            // Instantiate the CubePlayer for this client once we've successfully connected to the room
            materialDisc = Realtime.Instantiate("CubePlayer",                 // Prefab name
                                position: physicsDisc.transform.position,          // Start 1 meter in the air
                                rotation: physicsDisc.transform.rotation, // No rotation
                           ownedByClient: true,                // Make sure the RealtimeView on this prefab is owned by this client
                preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                             useInstance: realtime);           // Use the instance of Realtime that fired the didConnectToRoom event.
            materialDisc.transform.parent = physicsDisc.transform;
        }
    }
}
