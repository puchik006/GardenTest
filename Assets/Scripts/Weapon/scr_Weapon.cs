using UnityEngine;

public class scr_Weapon: MonoBehaviour
{
    [SerializeField] private scr_Weapon_Data _data; 
    [SerializeField] private Transform _firePoint;
    private SpriteRenderer _weaponSprite;
    private scr_Weapon_Bullet _weaponBullet;
    private float _bulletSpeed;
    private float _fireRate;
    private float _nextFireTime;

    void Awake()
    {
        _weaponSprite = GetComponent<SpriteRenderer>();
        scr_EventBus.Instance.FireButtonPressed += OnFireButtonPressed;
    }

    void Start()
    {
        V_ReadWeaponData();
    }

    private void V_ReadWeaponData()
    {
        _weaponSprite.sprite = _data.Picture;
        _firePoint.localPosition = _data.FirePoint;
        _weaponBullet = _data.Weapon_Bullet;
        _bulletSpeed = _data.BulletSpeed;
        _fireRate = _data.FireRate;
    }

    private void OnFireButtonPressed()
    {
        if (Time.time >= _nextFireTime)
        {
            FireBullet();
            _nextFireTime = Time.time + 1f / _fireRate;
        }
    }

    private void FireBullet()
    {
        var bullet = Instantiate(_weaponBullet, _firePoint.position, _weaponBullet.transform.rotation);
        bullet.V_Initialise(_bulletSpeed);
    }
}



