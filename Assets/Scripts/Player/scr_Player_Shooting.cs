using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public scr_Weapon_Data[] weapons; // Array of weapons
    private int currentWeaponIndex = 0; // Index of the current weapon
    private float nextFireTime = 0f; // Time when the player can fire next

    void Update()
    {
        // Switch weapon with number keys (1, 2, 3, ...)
        for (int i = 0; i < weapons.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                currentWeaponIndex = i;
                break;
            }
        }

        // Check for input to shoot
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / weapons[currentWeaponIndex].FireRate;
        }
    }

    void Shoot()
    {
        scr_Weapon_Data currentWeapon = weapons[currentWeaponIndex];

        // Instantiate the projectile at the fire point position and rotation
       // GameObject projectile = Instantiate(currentWeapon.Bullet, currentWeapon.FirePoint.position, currentWeapon.FirePoint.rotation);

        // Get the Rigidbody2D component of the projectile
        //Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile
        //rb.velocity = currentWeapon.FirePoint.right * currentWeapon.BulletSpeed;
    }
}
