using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyGoblin>(out EnemyGoblin enemy))
        {
            TakeDamage(enemy.DealDamage());
        }
    }
}