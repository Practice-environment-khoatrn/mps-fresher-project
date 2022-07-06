using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzleFlash;
    [SerializeField]
    private GameObject _flashLight;
    private float _lastShowTime;
    [SerializeField]
    private float _duration;

    private void Update()
    {
        if (!_muzzleFlash.gameObject.activeSelf) return;
        if (Time.time - _lastShowTime >= _duration)
        {
            Hide();
        }
    }

    private void OnEnable()
    {
        Hide();
    }

    public void Show()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        _muzzleFlash.gameObject?.SetActive(true);
        _flashLight.SetActive(true);
        float angle = Random.Range(0, 360f);
        _muzzleFlash.localRotation = Quaternion.Euler(0, 0, angle);
        _lastShowTime = Time.time;
    }

    private void Hide()
    {
        _flashLight.SetActive(false);
        _muzzleFlash.gameObject?.SetActive(false);
    }
}
