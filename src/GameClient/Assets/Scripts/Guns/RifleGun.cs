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
    
    private const float SECONDS_PER_MINUTE = 60f;
    private readonly int FireStateAnimHash = Animator.StringToHash("AlternateSingleFire");

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private int _rpm;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Transform _aimingCamera;
    [SerializeField]
    private float _damage;
    [HideInInspector]
    [SerializeField]
    private HitEffectManager _hitEffectManager;
    
    private float _lastShotTime;

    private void OnValidate()
    {
        _hitEffectManager = GetComponent<HitEffectManager>();
    }

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
        Raycast();
        OnShoot.Invoke();
    }

    private void Raycast()
    {
        Ray aimingRay = new Ray(_aimingCamera.position, _aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo))
        {
            ProceedDamage(hitInfo);
            CreateHitEffect(hitInfo);
        }
    }

    private void ProceedDamage(RaycastHit hitInfo)
    {
        Health enemyHealth = hitInfo.transform.gameObject.GetComponentInParent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDamaged(_damage);
        }
    }

    private void CreateHitEffect(RaycastHit hitInfo)
    {
        _hitEffectManager.CreateHitEffect(hitInfo);
    }

    public void PlayFireSound()
    {
        _audioSource.Play();
    }

    public void Lock() => enabled = false;
    public void Unlock() => enabled = true;
}
