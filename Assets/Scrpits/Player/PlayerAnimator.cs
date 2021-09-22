using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerGroundCheck _groundCheck;
    private PlayerMover _playerMover;
    private Rigidbody2D _rigidbody;
    private Player _player;

    private const string IsWalking = "IsWalking";
    private const string IsGrounded = "IsGrounded";
    private const string YVelocity = "yVelocity";
    private const string Hitted = "Hitted";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _groundCheck = GetComponent<Player>().GetComponentInChildren<PlayerGroundCheck>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalking, _playerMover.IsWalking);
        _animator.SetBool(IsGrounded, _groundCheck.IsGrounded);
        _animator.SetFloat(YVelocity, _rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _animator.SetTrigger(Hitted);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _animator.SetTrigger(Hitted);
        }
    }
}