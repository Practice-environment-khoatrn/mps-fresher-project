using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private Rigidbody[] _rigidbodies;
    [SerializeField, HideInInspector]
    private NavMeshAgent _navMeshAgent;
    [SerializeField, HideInInspector]
    private Animator _animator;

    private void OnValidate()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRagdoll(true);

    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll() => SetRagdoll(false);

    private void SetRagdoll(bool enableValue)
    {
        _navMeshAgent.enabled = !enableValue;
        _animator.enabled = !enableValue;
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = !enableValue;
        }
    }
}
