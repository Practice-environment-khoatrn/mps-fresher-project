using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BossNavigation : MonoBehaviour
{
    private bool _canNavigate = true;

    [SerializeField]
    private EnemyManager _enemyManager;
    [SerializeField]
    private float _attackRange;
    [HideInInspector]
    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    public UnityEvent OnWalk;
    public UnityEvent OnAttack;

    private void OnValidate()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_canNavigate)
        {
            UpdateNavigation();
        }
    }

    private void UpdateNavigation()
    {
        Vector3 playerFootPos = _enemyManager.playerFoot.position;
        float distance = Vector3.Distance(transform.position, playerFootPos);
        if (distance > _attackRange)
        {
            WalkToPlayer(playerFootPos);
        }
        else
        {
            AttackPlayer();
        }
    }

    private void WalkToPlayer(Vector3 playerFootPos)
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(playerFootPos);
        OnWalk.Invoke();
    }

    private void AttackPlayer()
    {
        _navMeshAgent.isStopped = true;
        OnAttack.Invoke();
    }

    public void StopNagivation()
    {
        _canNavigate = false;
        if (_navMeshAgent.enabled) _navMeshAgent.isStopped = true;
    }
}
