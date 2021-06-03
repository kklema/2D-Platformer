using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _mover.MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _mover.MoveLeft();
        }
        else
        {
            _mover.StopHorizontalMovement();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _mover.Jump();
        }
    }
}