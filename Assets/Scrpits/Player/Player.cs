using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

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
        if (collision.collider.TryGetComponent<EnemyGoblin>(out EnemyGoblin enemy))
        {
            TakeDamage(enemy.DealDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gem>(out Gem gem))
        {
            TakeHeal(gem.DealHealing());
        }
    }
}