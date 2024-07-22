using UnityEngine;

public class scr_Enemy : MonoBehaviour
{
    [SerializeField] private scr_Enemy_Data _data;
    private Rigidbody2D _rigidbody2D;
    private Transform _playerTransform;
    private bool _isChasing = false;

    [SerializeField] private int _HP;

    void OnValidate()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        _HP = _data.HP;
    }


    void Update()
    {
        if (_isChasing && _playerTransform != null)
        {
            Vector2 direction = (_playerTransform.position - transform.position).normalized;
            _rigidbody2D.velocity = direction * _data.Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerTransform = collision.transform;
            _isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isChasing = false;
            _rigidbody2D.velocity = Vector2.zero; // Stop the enemy
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");
            // Add damage logic here if needed
        }
    }

    public void V_TakeDamage(int damage)
    {
        _HP -= damage;
        Debug.Log("Enemy took " + damage + " damage, health now " + _HP);

        if (_HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void V_DropItem()
    {

    }
}
