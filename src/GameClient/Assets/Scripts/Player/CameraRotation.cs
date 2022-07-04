using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private void Update()
    {
        UpdateYaw();
    }

    private void UpdateYaw()
    {
        float yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0, yaw, 0);
    }
}
