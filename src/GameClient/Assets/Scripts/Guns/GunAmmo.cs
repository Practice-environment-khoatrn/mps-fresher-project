using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    private readonly int ReloadTrigger = Animator.StringToHash("Reload");

    [field: SerializeField]
    public int RemainingAmmo { get; private set; }
    [SerializeField]
    private RifleGun _rifleGun;
    [HideInInspector]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private AudioSource[] _reloadSounds;
    [SerializeField]
    private int _magazineSize;
    private int _loadedAmmo;

    public int GetMagazineSize()
    {
        return _magazineSize;
    }

    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            UpdateGunLock();
            OnAmmoChanged?.Invoke();
        }
    }

    public Action OnAmmoChanged { get; set; }

    private bool _isReloading;



    private void OnEnable()
    {
        _isReloading = false;
        UnlockShooting();
    }

    private void UpdateGunLock()
    {
        if (LoadedAmmo <= 0)
        {
            _rifleGun.Lock();
        }
        else
        {
            // moved
            // _shooting.Unlock();
        }
    }

    private void OnValidate()
    {
        // Lay tu dong
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        LoadedAmmo = _magazineSize;
        _rifleGun.OnShoot.AddListener(OnShoot);
    }

    private void OnShoot() => LoadedAmmo--;

    private void Update()
    {
        if (_isReloading) return;

        if (Input.GetKeyDown(KeyCode.R) || LoadedAmmo == 0)
        {
            Reload();
        }
    }

    private void Reload()
    {
        if (RemainingAmmo > 0 && LoadedAmmo != _magazineSize)
        {
            _animator.SetTrigger(ReloadTrigger);
            _isReloading = true;

            // dang nap dan phai lock ban
            LockShooting();
        }
    }

    public void AddAmmo()
    {
        int requiredAmmo = _magazineSize - LoadedAmmo;
        int addedAmmo = Mathf.Min(requiredAmmo, RemainingAmmo);

        RemainingAmmo -= addedAmmo;
        LoadedAmmo += addedAmmo;
    }

    public void PlayReloadPart1Sound() => _reloadSounds[0].Play();
    public void PlayReloadPart2Sound() => _reloadSounds[1].Play();

    public void ReloadToIdle()
    {
        _isReloading = false;
        _rifleGun.Unlock();
    }

    private void UnlockShooting()
    {
        if (LoadedAmmo > 0)
        {
            _rifleGun.Unlock();
        }
    } 

    private void LockShooting()
    {
        _rifleGun.Lock();
    }
}
