using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _hp;

    public UnityEvent OnDie;

    public void OnDamaged(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            OnDie.Invoke();
        }
    }
}
