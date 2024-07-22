using UnityEngine;

public class scr_Weapon_Bullet : MonoBehaviour
{
    private float _speed;
    private int _damage;

    public void V_Initialise(float speed, int damage)
    {
        _speed = speed;
        _damage = damage;
    }

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet hit " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<scr_Enemy>();

            if (enemy != null)
            {
                enemy.V_TakeDamage(_damage); 
            }
        }

        Destroy(gameObject);
    }
}



