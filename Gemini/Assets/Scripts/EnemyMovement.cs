using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 5f; // Adjust speed for enemy movement
    public Transform playerTransform; // Reference to the player's transform
    private Rigidbody2D enemyRigidbody; // Reference to the enemy's Rigidbody2D component
    private Camera mainCamera; // Reference to the main camera
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float fireRateMin = 1f; // Minimum time between shots (seconds)
    public float fireRateMax = 3f; // Maximum time between shots (seconds)
    private float nextFireTime; // Time of the next projectile shot

    void Start()
    {
        // Get the enemy's Rigidbody2D component
        enemyRigidbody = GetComponent<Rigidbody2D>();

        // Find the player GameObject (assuming it's tagged as "Player")
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the main camera
        mainCamera = Camera.main;

        // Calculate initial fire time
        nextFireTime = Time.time + Random.Range(fireRateMin, fireRateMax);
    }

    void FixedUpdate() // Update for physics
    {
        // Set enemy velocity to move left at constant speed
        enemyRigidbody.velocity = Vector2.left * enemySpeed;

        // Check if enemy is outside camera view on the left (already implemented)
        // ... (existing code for checking and destroying enemy outside camera)

        // Check if it's time to shoot and player is visible
        if (Time.time >= nextFireTime && IsPlayerVisible())
        {
            ShootProjectile();

            // Calculate the next fire time
            nextFireTime = Time.time + Random.Range(fireRateMin, fireRateMax);
        }
    }

    void ShootProjectile()
    {
        // Calculate direction based on player's X velocity (assuming positive right)
        Vector2 direction = playerTransform.GetComponent<Rigidbody2D>().velocity.normalized;

        // Create a new projectile instance facing the player's movement direction
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    bool IsPlayerVisible()
    {
        // Simplified check assuming player is always within camera bounds vertically
        float screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float playerWorldX = playerTransform.position.x;
        return Mathf.Abs(playerWorldX) < screenHalfWidth + Mathf.Abs(playerTransform.localScale.x / 2f);
    }
}
