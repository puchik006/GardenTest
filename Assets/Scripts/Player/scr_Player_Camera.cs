using UnityEngine;

public class scr_Player_Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (_player == null) return;

        Vector3 desiredPosition = _player.position + _offset;

        desiredPosition.z = transform.position.z;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
    }
}
