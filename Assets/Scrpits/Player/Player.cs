using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private bool _isHitted = false;

    public bool IsHitted => _isHitted;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
    }
}