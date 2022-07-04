using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float _upperLimitAngle;
    [SerializeField]
    private float _lowerLimitAngle;
    [SerializeField]
    private float _lookSpeed;
    [SerializeField]
    private Transform _playerCamera;

    const float FullCircleDegree = 2 * Mathf.PI * Mathf.Rad2Deg;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float yaw = SimpleInput.GetAxis("Look Joystick X");
        transform.Rotate(0, yaw * _lookSpeed, 0);
    }

    private void UpdatePitch()
    {
        float pitch = SimpleInput.GetAxis("Look Joystick Y");
        ClampPitch(ref pitch);
        _playerCamera.transform.Rotate(-pitch * _lookSpeed, 0, 0);
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
