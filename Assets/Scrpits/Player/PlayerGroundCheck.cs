using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground) || collision.TryGetComponent<Wall>(out Wall wall))
        {
            _isGrounded = true;
            Debug.Log("На земле");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground) || collision.TryGetComponent<Wall>(out Wall wall))
        {
            _isGrounded = false;
            Debug.Log("В воздухе");
        }
    }
}