using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float _upperLimitAngle;
    [SerializeField]
    private float _lowerLimitAngle;
    [SerializeField]
    private Transform _playerCamera;

    const float FullCircleDegree = 2 * Mathf.PI * Mathf.Rad2Deg;

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
        ClampPitch(ref pitch);
        _playerCamera.transform.Rotate(-pitch, 0, 0);
    }

    private void ClampPitch(ref float pitch)
    {
        float localXAngle = _playerCamera.transform.localEulerAngles.x;
        ClampUpperPitch(ref pitch, localXAngle);
        ClampLowerPitch(ref pitch, localXAngle);
    }

    private void ClampUpperPitch(ref float pitch, float localXAngle)
    {
        if (localXAngle > FullCircleDegree / 2)
        {
            if ((localXAngle < FullCircleDegree - _upperLimitAngle) && pitch > 0)
            {
                pitch = 0;
            }
        }
    }

    private void ClampLowerPitch(ref float pitch, float localXAngle)
    {
        if (localXAngle < FullCircleDegree / 2)
        {
            if (localXAngle > -_lowerLimitAngle && pitch < 0)
            {
                pitch = 0;
            }
        }
    }
}
