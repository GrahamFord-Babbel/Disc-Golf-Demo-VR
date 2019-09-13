using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonNetworkManager : MonoBehaviour
{
    //script incomplete

    //public override void OnJoinedRoom()
    //{
    //    GameObject localAvatar = Instantiate(Resources.Load("LocalAvatar")) as GameObject;
    //    PhotonView photonView = localAvatar.GetComponent<PhotonView>();

    //    if (PhotonNetwork.AllocateViewID(photonView))
    //    {
    //        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
    //        {
    //            CachingOption = EventCaching.AddToRoomCache,
    //            Receivers = ReceiverGroup.Others
    //        };

    //        SendOptions sendOptions = new SendOptions
    //        {
    //            Reliability = true
    //        };

    //        PhotonNetwork.RaiseEvent(InstantiateVrAvatarEventCode, photonView.ViewID, raiseEventOptions, sendOptions);
    //    }
    //    else
    //    {
    //        Debug.LogError("Failed to allocate a ViewId.");

    //        Destroy(localAvatar);
    //    }
    //}
}
