using Assets.Scripts.MyInputManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RifleGun : MonoBehaviour
{
    public UnityEvent OnShoot;
    
    private const int SECONDS_PER_MINUTE = 60;
    private readonly int FireStateAnimHash = Animator.StringToHash("AlternateSingleFire");

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private int _rpm;
    [SerializeField]
    private Animator _animator;
    
    private float _lastShotTime;

    private void Update()
    {
        if (MyInputManager.GetButton("Shoot"))
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
        OnShoot.Invoke();
    }

    public void PlayFireSound()
    {
        _audioSource.Play();
    }
}
