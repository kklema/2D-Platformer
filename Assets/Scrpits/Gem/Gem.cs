using UnityEngine;

public class Gem : MonoBehaviour
{
    private bool _activ;

    public bool Activ => _activ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            gameObject.SetActive(false);
            _activ = false;
        }
    }
}