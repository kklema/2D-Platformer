using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _heal;

    private bool _activ;

    public bool Activ => _activ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeHeal(_heal);
            gameObject.SetActive(false);
            _activ = false;
        }
    }
}