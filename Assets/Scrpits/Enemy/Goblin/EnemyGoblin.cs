using UnityEngine;

public class EnemyGoblin : MonoBehaviour
{
    [SerializeField] int _damage;

    public int DealDamage()
    {
        return _damage;
    }
}