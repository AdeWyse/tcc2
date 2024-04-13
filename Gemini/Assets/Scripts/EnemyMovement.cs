using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 5f; // Adjust speed for enemy movement
    private Rigidbody2D enemyRigidbody; // Reference to the enemy's Rigidbody2D component
    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        // Get the enemy's Rigidbody2D component
        enemyRigidbody = GetComponent<Rigidbody2D>();

        // Get the main camera
        mainCamera = Camera.main;
    }

    void FixedUpdate() // Update for physics
    {
        // Set enemy velocity to move left at constant speed
        enemyRigidbody.velocity = Vector2.left * enemySpeed;

        // Check if enemy is outside camera view on the left
        float screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float enemyWorldX = transform.position.x;

        if (enemyWorldX + Mathf.Abs(transform.localScale.x / 2f) < -screenHalfWidth)
        {
            Destroy(gameObject);
        }
    }
}
