using UnityEngine;

public class scr_Weapon_Bullet : MonoBehaviour
{
    private float _speed;

    public void V_Initialise(float speed)
    {
        _speed = speed;
    }

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet hit " + collision.name);
        Destroy(gameObject); 
    }
}



