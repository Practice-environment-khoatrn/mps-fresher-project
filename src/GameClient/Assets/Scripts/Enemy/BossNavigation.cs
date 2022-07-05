using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossNavigation : MonoBehaviour
{
    [SerializeField]
    private EnemyManager _enemyManager;
    [SerializeField]
    private float _attackRange;
    [HideInInspector]
    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    private void OnValidate()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        UpdateNavigation();
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
    }

    private void AttackPlayer()
    {
        _navMeshAgent.isStopped = true;
        Debug.Log("Attacking player");
    }
}
