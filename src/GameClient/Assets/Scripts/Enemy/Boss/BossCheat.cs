using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheat : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _cheatSpeed;
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    public void CheatSpeed()
    {
        _animator.SetFloat(SpeedHash, _cheatSpeed);
    }
}
