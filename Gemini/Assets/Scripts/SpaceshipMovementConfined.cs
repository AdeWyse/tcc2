using UnityEngine;

public class SpaceshipMovementConfined : MonoBehaviour
{
    public float spaceshipSpeed = 5f; // Adjust speed for spaceship movement

    private Rigidbody2D spaceshipRigidbody; // Reference to the spaceship's Rigidbody2D component
    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        // Get the spaceship's Rigidbody2D component
        spaceshipRigidbody = GetComponent<Rigidbody2D>();

        // Get the main camera
        mainCamera = Camera.main;
    }

    void FixedUpdate() // Use FixedUpdate for physics updates
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal axis input (A/D)
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical axis input (W/S)

        // Move the spaceship based on input and speed
        spaceshipRigidbody.velocity = new Vector2(horizontalInput * spaceshipSpeed, verticalInput * spaceshipSpeed);

        // Confine spaceship position to half of the screen (left side)
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -mainCamera.orthographicSize * mainCamera.aspect + spaceshipRigidbody.transform.localScale.x / 2f, 0f);
        newPosition.y = Mathf.Clamp(newPosition.y, -mainCamera.orthographicSize + spaceshipRigidbody.transform.localScale.y / 2f, mainCamera.orthographicSize - spaceshipRigidbody.transform.localScale.y / 2f);

        // Update the spaceship's position with clamping
        transform.position = newPosition;
    }
}
