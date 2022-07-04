using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _moveSpeed;

    private void OnValidate()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveByKey();
    }

    private void MoveByKey()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * zMove + transform.right * xMove;
        _characterController.SimpleMove(moveDirection * _moveSpeed);
    }
}
