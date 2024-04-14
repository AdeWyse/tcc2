using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemyProjectilePrefab; // Reference to the enemy projectile prefab
    public float minShootInterval = 2f; // Minimum interval between shots
    public float maxShootInterval = 5f; // Maximum interval between shots
    public float minEnemySpeed = 3f; // Minimum enemy speed
    public float maxEnemySpeed = 5f; // Maximum enemy speed
    public float minProjectileSpeedOffset = 2f; // Minimum offset for projectile speed relative to enemy speed
    public float maxProjectileSpeedOffset = 4f; // Maximum offset for projectile speed relative to enemy speed

    private GameObject player; // Reference to the player GameObject
    private float enemySpeed; // Speed of the enemy

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Set random enemy speed between minEnemySpeed and maxEnemySpeed
        enemySpeed = Random.Range(minEnemySpeed, maxEnemySpeed);

        // Start shooting coroutine
        StartCoroutine(ShootProjectiles());
    }

    IEnumerator ShootProjectiles()
    {
        while (true)
        {
            // Calculate interval between shots
            float shootInterval = Random.Range(minShootInterval, maxShootInterval);
            yield return new WaitForSeconds(shootInterval);

            // Determine direction to shoot (always to the left)
            Vector3 direction = Vector3.left;

            // Calculate projectile speed offset relative to enemy speed
            float projectileSpeedOffset = Random.Range(minProjectileSpeedOffset, maxProjectileSpeedOffset);

            // Set projectile speed to be higher than enemy speed
            float projectileSpeed = enemySpeed + projectileSpeedOffset;

            // Instantiate enemy projectile
            GameObject projectile = Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }

    void Update()
    {
        // Move the enemy towards the left
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);

        // Check if the enemy has left the camera view on the left side
        if (IsOutsideCameraView())
        {
            Destroy(gameObject);
        }
    }

    bool IsOutsideCameraView()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        return screenPos.x < 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase the score when an enemy collides with the player
            FindObjectOfType<ScoreManager>().AddPoints(5);
            // Destroy the enemy
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            // Increase the score when an enemy is hit by a player projectile
            FindObjectOfType<ScoreManager>().AddPoints(5);
            // Destroy the enemy
            Destroy(gameObject);
            // Destroy the projectile
            Destroy(collision.gameObject);
        }
    }
}
