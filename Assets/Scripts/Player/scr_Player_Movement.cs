using UnityEngine;

public class scr_Player_Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Joystick _joystick; 

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = _joystick.Horizontal;
        movement.y = _joystick.Vertical;

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * _moveSpeed * Time.fixedDeltaTime);
    }
}
