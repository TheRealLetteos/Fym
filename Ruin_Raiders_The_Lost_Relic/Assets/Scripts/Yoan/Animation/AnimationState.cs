using System.Collections;
using System.Collections.Generic;
using fym;
using UnityEngine;

public class AnimationState : MonoBehaviour
{

    private Player _player;

    private Animator _animator;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        SetStates();
    }

    private void SetStates()
    {
        _animator.SetBool("IsJumping", _player.IsJumping); 
        _animator.SetBool("IsMoving", _player.IsMoving);
        _animator.SetBool("IsGrounded", _player.IsGrounded);
        _animator.SetBool("IsDashing", _player.IsDashing);
        _animator.SetBool("IsAttacking", _player.IsAttacking);
    }
}
