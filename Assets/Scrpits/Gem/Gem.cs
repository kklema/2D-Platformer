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
            DealHealing();
            gameObject.SetActive(false);
            _activ = false;
        }
    }

    public int DealHealing()
    {
        return _heal;
    }
}