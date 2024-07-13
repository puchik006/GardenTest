using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class scr_Weapon_Data : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _picture;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _fireRate = 1f;

    public string Name => _name;
    public GameObject Bullet => _bullet;
    public float BulletSpeed => _bulletSpeed;
    public float FireRate => _fireRate;
}
