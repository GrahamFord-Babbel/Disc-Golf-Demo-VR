﻿using UnityEngine;
using Normal.Realtime;
public class GrabRequest : MonoBehaviour
{
    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTransform;
    private void Awake()
    {
        _realtimeView = GetComponent<RealtimeView>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
    }
    private void Update()
    {
        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            print("THIS HAS BEEN GRABBED");
            _realtimeTransform.RequestOwnership();
        }
    }
}