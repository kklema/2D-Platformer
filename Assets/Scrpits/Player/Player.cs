using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private Animator _animator;

    private bool _isHitted = false;

    public bool IsHitted => _isHitted;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void TakeHeal(int heal)
    {
        _health += heal;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyGoblin>(out EnemyGoblin goblin))
        {
            TakeDamage(goblin.DealDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gem>(out Gem gem))
        {
            TakeHeal(gem.DealHealing());
        }

        if (collision.TryGetComponent<EnemyFlyingEye>(out EnemyFlyingEye eye))
        {
            TakeDamage(eye.DealDamage());
        }
    }
}