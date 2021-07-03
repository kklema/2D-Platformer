using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isWalking;

    private Rigidbody2D _rigidbody;
    private PlayerGroundCheck _groundCheck;

    private bool _isJumping;

    public bool IsWalking => _isWalking;
    public bool IsJumping => _isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<Player>().GetComponentInChildren<PlayerGroundCheck>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.x != 0)
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
    }

    private void DoHorizontalMovement(float speed)
    {
        _isWalking = true;
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
        FlipSide(speed);
    }

    private void DoVerticalMovement()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    private void FlipSide(float speed)
    {
        if (speed > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (speed < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void MoveRight()
    {
        DoHorizontalMovement(_speed);
    }

    public void MoveLeft()
    {
        DoHorizontalMovement(-_speed);
    }

    public void Jump()
    {
        if (_groundCheck.IsGrounded)
        {
            DoVerticalMovement();
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
    }

    public void StopHorizontalMovement()
    {
        _isWalking = false;
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}