using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f; // Adjust speed for projectile movement
    private Camera mainCamera; // Reference to the main camera

    private Rigidbody2D projectileRigidbody; // Reference to the projectile's Rigidbody2D component

    void Start()
    {
        // Get the projectile's Rigidbody2D component
        projectileRigidbody = GetComponent<Rigidbody2D>();

        // Set initial velocity based on projectileSpeed sign
        projectileRigidbody.velocity = Vector2.right * projectileSpeed;

        // Get the main camera
        mainCamera = Camera.main;
    }

    void Update() // Update for camera check (alternative approach)
    {
        // Check if projectile is outside camera view (assuming orthographic camera)
        float screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float projectileWorldX = transform.position.x;

        if (Mathf.Abs(projectileWorldX) > screenHalfWidth + Mathf.Abs(transform.localScale.x / 2f))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // Use OnCollisionEnter2D for 2D collisions
    {
        // Destroy the projectile on collision
        Destroy(gameObject);
    }
}


