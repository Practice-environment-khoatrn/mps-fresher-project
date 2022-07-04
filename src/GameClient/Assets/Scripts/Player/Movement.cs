using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform _playerTransform;
    private CharacterController _playerCharacterController;

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private GameObject _fpsPlayer;

    private void OnValidate()
    {
        _playerTransform = _fpsPlayer.GetComponent<Transform>();
        _playerCharacterController = _fpsPlayer.GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveByKey();
        MoveByJoystick();
    }

    private void MoveByKey()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 moveDirection = _playerTransform.forward * zMove + _playerTransform.right * xMove;
        _playerCharacterController.SimpleMove(moveDirection * _moveSpeed);
    }

    private void MoveByJoystick()
    {
        float xMove = SimpleInput.GetAxis("Move Joystick X");
        float zMove = SimpleInput.GetAxis("Move Joystick Y");
        Vector3 moveDirection = _playerTransform.forward * zMove + _playerTransform.right * xMove;
        _playerCharacterController.SimpleMove(moveDirection * _moveSpeed);
    }
}
