using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
//[RequireComponent(typeof(PlayerGroundCheck))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private GroundCheck _groundCheck;
    private PlayerMover _playerMover;
    private Rigidbody2D _rb;

    private bool _isGrounded => _groundCheck.IsGrounded;

    private bool _isJumping;
    private bool _isFalling;

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
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("yVelocity", _rb.velocity.y);
    }
}