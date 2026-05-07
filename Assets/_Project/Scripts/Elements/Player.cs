using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    public void RestartPlayer()
    {

    }

    private void Update()
    {
        var dir = Vector2.zero;

        if (Keyboard.current.dKey.isPressed)
        {
            dir = Vector2.right;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            dir = Vector2.left;
        }

        rb.linearVelocity = dir * speed;

    }
}
