using UnityEngine;

public class SpaceshipMovementShooting : MonoBehaviour
{
    public float spaceshipSpeed = 5f; // Adjust speed for spaceship movement
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float fireRate = 0.1f; // Time between shots in seconds

    private Rigidbody2D spaceshipRigidbody; // Reference to the spaceship's Rigidbody2D component
    private Camera mainCamera; // Reference to the main camera
    private float lastShotTime = Mathf.NegativeInfinity; // Tracks time of last shot (initially set to negative infinity)

    void Start()
    {
        // Get the spaceship's Rigidbody2D component
        spaceshipRigidbody = GetComponent<Rigidbody2D>();

        // Get the main camera
        mainCamera = Camera.main;
    }

    void Update() // Update for input handling
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal axis input (A/D)
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical axis input (W/S)

        // Move the spaceship based on input and speed
        spaceshipRigidbody.velocity = new Vector2(horizontalInput * spaceshipSpeed, verticalInput * spaceshipSpeed);

        // Confine spaceship position to half of the screen (left side)
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -mainCamera.orthographicSize * mainCamera.aspect + spaceshipRigidbody.transform.localScale.x / 2f, 0f);
        newPosition.y = Mathf.Clamp(newPosition.y, -mainCamera.orthographicSize + spaceshipRigidbody.transform.localScale.y / 2f, mainCamera.orthographicSize - spaceshipRigidbody.transform.localScale.y / 2f);
        transform.position = newPosition;

        // Check for shoot input and fire rate
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShotTime >= fireRate) // Check if enough time has passed since last shot
            {
                ShootProjectile();
                lastShotTime = Time.time; // Update last shot time
            }
        }
    }

    void ShootProjectile()
    {
        // Create a new projectile instance
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

    }
}
