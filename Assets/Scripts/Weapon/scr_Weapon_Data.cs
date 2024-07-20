using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class scr_Weapon_Data : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _picture;
    [SerializeField] private Vector2 _firePoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private scr_Weapon_Bullet _Weapon_Bullet;

    public string Name => _name;
    public float BulletSpeed => _bulletSpeed;
    public float FireRate => _fireRate;
    public Sprite Picture => _picture;
    public Vector2 FirePoint => _firePoint;
    public scr_Weapon_Bullet Weapon_Bullet => _Weapon_Bullet;
}
