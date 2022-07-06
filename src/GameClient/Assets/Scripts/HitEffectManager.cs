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
            DestroyFirstHitEffect();
        }
        CreateNewHitEffect(hitInfo);
    }

    private void DestroyFirstHitEffect()
    {
        GameObject firstHitEffect = _hitEffects.Dequeue();
        Destroy(firstHitEffect);
    }

    private void CreateNewHitEffect(RaycastHit hitInfo)
    {
        Quaternion hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        GameObject hitEffect = Instantiate(_hitEffect, hitInfo.point, hitEffectRotation);
        _hitEffects.Enqueue(hitEffect);
    }
}
