using UnityEngine;

public class scr_Player_Camera : MonoBehaviour
{
    [SerializeField] private Transform _player; // Reference to the player's transform
    [SerializeField] private Vector3 _offset; // Offset between the camera and the player
    [SerializeField] private float _smoothSpeed = 0.125f; // Smooth speed for camera movement

    void LateUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;

        desiredPosition.z = transform.position.z;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
    }
}
