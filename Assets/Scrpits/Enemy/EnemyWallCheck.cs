using UnityEngine;

public class EnemyWallCheck : MonoBehaviour
{
    private bool _wall;

    public bool Wall => _wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Wall>(out Wall wall))
        {
            _wall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Wall>(out Wall wall))
        {
            _wall = !_wall;
        }
    }
}