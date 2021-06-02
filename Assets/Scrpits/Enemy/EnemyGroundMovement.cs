using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Transform))]
public class EnemyGroundMovement : MonoBehaviour
{
    private Transform _facingSide;

    [SerializeField] private float _speed;
    [SerializeField] private float _castPosDistance;

    private EnemyWallCheck _wallCheck;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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

            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
}