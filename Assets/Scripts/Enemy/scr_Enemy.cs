using UnityEngine;

public class scr_Enemy : MonoBehaviour
{
    [SerializeField] private scr_Enemy_Data _data;
    [SerializeField] private scr_UI_DropableItem _dropableItemPrefab;
    [SerializeField] private scr_UI_HealthBar _healthBarPrefab;
    private Rigidbody2D _rigidbody2D;
    private Transform _playerTransform;
    private bool _isChasing = false;
    private string _itemToDrop;
    private int _HP;
    private float _fullHP;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _HP = _data.HP;
        _fullHP = (float)_data.HP;
        _itemToDrop = _data.ItemToDrop;
    }


    void Update()
    {
        if (_isChasing && _playerTransform != null)
        {
            Vector2 direction = (_playerTransform.position - transform.position).normalized;
            _rigidbody2D.velocity = direction * _data.Speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerTransform = collision.transform;
            _isChasing = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        _isChasing = false;
    //        _rigidbody2D.velocity = Vector2.zero; // Stop the enemy
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");

        }
    }

    public void V_TakeDamage(int damage)
    {
        _HP -= damage;

        _healthBarPrefab.V_ChangeHealthBalue(damage/_fullHP);

        Debug.Log("Enemy took " + damage + " damage, health now " + _HP);

        if (_HP <= 0)
        {
            V_DropItem();
            Destroy(gameObject);
        }
    }

    private void V_DropItem()
    {
        Debug.Log($"Drop item {_itemToDrop}");
        var item = Instantiate(_dropableItemPrefab, transform.position, Quaternion.identity);
        item.V_InitialiseItem(_itemToDrop);
    }
}
