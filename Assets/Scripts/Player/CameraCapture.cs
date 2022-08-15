using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraCapture : MonoBehaviour
{
    #region Singleton

    public static CameraCapture Instance;

    private void Awake()
    {
        Instance = this;
        _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
    }

    #endregion
    
    private CinemachineVirtualCamera _cinemachineCamera;

    public void CaptureTarget(Transform target)
    {
        _cinemachineCamera.Follow = target;
        _cinemachineCamera.LookAt = target;
    }
}
