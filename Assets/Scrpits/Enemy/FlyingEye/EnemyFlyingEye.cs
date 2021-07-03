using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingEye : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int DealDamage()
    {
        return _damage;
    }
}
