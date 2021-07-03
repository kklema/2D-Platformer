using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private UnityEvent _soundEvent;

    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        MakeSound();
    }

    public void MakeSound()
    {
        switch (true)
        {
            case "Jump":
                break;
        }

        _soundEvent?.Invoke();
    }
}