using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MyClass : MonoBehaviourPunCallbacks //, IOnEventCallback
{

    //incomplete, likely delete

    //public void OnEvent(EventData photonEvent)
    //{
    //    if (photonEvent.Code == InstantiateVrAvatarEventCode)
    //    {
    //        GameObject remoteAvatar = Instantiate(Resources.Load("RemoteAvatar")) as GameObject;
    //        PhotonView photonView = remoteAvatar.GetComponent<PhotonView>();
    //        photonView.ViewID = (int)photonEvent.CustomData;
    //    }
    //}
    //public void OnEnable()
    //{
    //    PhotonNetwork.AddCallbackTarget(this);
    //}

    //public void OnDisable()
    //{
    //    PhotonNetwork.RemoveCallbackTarget(this);
    //}

    //One last thing: make sure that the Avatar gets destroyed on each client when a player leaves the game. 
    //Also don't forget, to remove the stored event from the room's cache.

}
