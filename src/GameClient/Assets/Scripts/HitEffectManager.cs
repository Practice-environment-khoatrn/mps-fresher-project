using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    private Queue<GameObject> _hitEffects = new Queue<GameObject>();
    [SerializeField]
    private int _maximum;
    [SerializeField]
    private GameObject _hitEffect;

    public void CreateHitEffect(RaycastHit hitInfo)
    {
        if (_hitEffects.Count >= _maximum)
        {
            ReactivateFirstHitEffect(hitInfo);
        } 
        else
        {
            CreateNewHitEffect(hitInfo);
        }
    }

    private void ReactivateFirstHitEffect(RaycastHit hitInfo)
    {
        GameObject firstHitEffect = _hitEffects.Dequeue();
        firstHitEffect.SetActive(true);
        firstHitEffect.transform.SetPositionAndRotation(hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        _hitEffects.Enqueue(firstHitEffect);
    }

    private void CreateNewHitEffect(RaycastHit hitInfo)
    {
        Quaternion hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        GameObject hitEffect = Instantiate(_hitEffect, hitInfo.point, hitEffectRotation);
        _hitEffects.Enqueue(hitEffect);
    }
}
