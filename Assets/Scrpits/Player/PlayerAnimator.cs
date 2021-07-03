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
    private Rigidbody2D _rb;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _groundCheck = GetComponent<Player>().GetComponentInChildren<PlayerGroundCheck>();
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetBool("IsWalking", _playerMover.IsWalking);
        _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);
        _animator.SetFloat("yVelocity", _rb.velocity.y);
        //_animator.SetBool("IsHitted", _player.IsHitted);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyGoblin>(out EnemyGoblin goblin))
        {
            _animator.SetTrigger("Hitted");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyFlyingEye>(out EnemyFlyingEye eye))
        {
            _animator.SetTrigger("Hitted");
        }
    }
}