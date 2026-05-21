using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private ControlType controlType;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    public void RestartPlayer()
    {

    }

    private void Update()
    {
        if (controlType == ControlType.Keyboard)
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
        else if (controlType == ControlType.Mouse)
        {
            var mouseScreenPos = Mouse.current.position.ReadValue();
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0));

            var xPos = mouseWorldPos.x;
            xPos = Mathf.Clamp(xPos, -2f, 2f);

            transform.position = new Vector3(xPos, -4, 0);
        }
    }
}

public enum ControlType
{
    Keyboard,
    Mouse,
}