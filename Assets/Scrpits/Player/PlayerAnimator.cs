using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private GroundCheck _groundCheck;
    private PlayerMover _playerMover;
    private Rigidbody2D _rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _groundCheck = GetComponent<Player>().GetComponentInChildren<GroundCheck>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetBool("IsWalking", _playerMover.IsWalking);
        _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);
        _animator.SetFloat("yVelocity", _rb.velocity.y);
    }
}