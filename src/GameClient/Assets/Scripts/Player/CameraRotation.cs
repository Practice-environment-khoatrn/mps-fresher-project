using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private Transform _playerCamera;

    private void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0, yaw, 0);
    }

    private void UpdatePitch()
    {
        float pitch = Input.GetAxis("Mouse Y");
        _playerCamera.transform.Rotate(-pitch, 0, 0);
    }
}
