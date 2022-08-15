using System;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    private void Start()
    {
        CameraCapture.Instance.CaptureTarget(transform);
    }
}
