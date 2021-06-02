using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isWalking;

    private bool _isGrounded => _groundCheck.IsGrounded;

    private Rigidbody2D _rigidbody;
    private GroundCheck _groundCheck;

    public bool IsWalking => _isWalking;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<Player>().GetComponentInChildren<GroundCheck>();
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
        }
    }

    public void StopHorizontalMovement()
    {
        _isWalking = false;
        transform.Translate(new Vector2(0, 0));
    }

    private void DoHorizontalMovement(float speed)
    {
        _isWalking = true;
        transform.Translate(new Vector2(_speed, 0) * Time.deltaTime);
        FlipSide(speed);
    }

    private void DoVerticalMovement()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
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
}
