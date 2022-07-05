using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    private readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
    private readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

    [HideInInspector]
    [SerializeField]
    private Animator _animator;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayWalkAnimation()
    {
        _animator.SetBool(IsAttackingHash, false);
        _animator.SetBool(IsWalkingHash, true);
    }

    public void PlayAttackAnimation()
    {
        _animator.SetBool(IsWalkingHash, false);
        _animator.SetBool(IsAttackingHash, true);
    }
}
