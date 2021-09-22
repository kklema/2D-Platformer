using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Transform))]

public class EnemyGroundMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _castPosDistance;

    private Transform _facingSide;
    private EnemyWallCheck _wallCheck;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _facingSide = GetComponent<Transform>();
        _wallCheck = GetComponentInChildren<EnemyWallCheck>();
    }

    private void FixedUpdate()
    {
        if (_wallCheck.Wall)
        {
            _speed *= -1;
            _facingSide.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        }

            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }
}