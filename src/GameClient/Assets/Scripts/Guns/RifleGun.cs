using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RifleGun : MonoBehaviour
{
    private const int SECONDS_PER_MINUTE = 60;
    private readonly int FireStateAnimHash = Animator.StringToHash("AlternateSingleFire");

    [SerializeField]
    private int _rpm;
    [SerializeField]
    private Animator _animator;
    
    private float _lastShotTime;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            UpdateShooting();
        }
    }

    public void UpdateShooting()
    {
        float interval = SECONDS_PER_MINUTE / _rpm;
        if (Time.time - _lastShotTime >= interval)
        {
            Shoot();
            _lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        _animator.Play(FireStateAnimHash);
    }
}
