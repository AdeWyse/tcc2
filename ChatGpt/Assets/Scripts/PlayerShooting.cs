using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float projectileSpeed = 10f; // Speed of the projectile
    public float shootDelay = 0.3f; // Delay between shots

    private bool canShoot = true;

    void Update()
    {
        // Check for player input to shoot projectiles
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && canShoot)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        canShoot = false;

        // Instantiate a projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the direction towards the enemies (to the right)
        Vector3 direction = Vector3.right;

        // Apply speed to the projectile in the direction of the enemies
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }
}
