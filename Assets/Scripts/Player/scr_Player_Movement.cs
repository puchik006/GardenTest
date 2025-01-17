using UnityEngine;

public class scr_Player_Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private scr_UI_SimpleJoystick _joystick;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float joystickHorizontal = _joystick.Horizontal;
        float joystickVertical = _joystick.Vertical;

        movement.x = joystickHorizontal;
        movement.y = joystickVertical;

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement * _moveSpeed;
    }
}
