using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float spaceshipSpeed = 5f; // Adjust speed for spaceship movement

    private Rigidbody2D spaceshipRigidbody; // Reference to the spaceship's Rigidbody2D component

    void Start()
    {
        // Get the spaceship's Rigidbody2D component
        spaceshipRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() // Use FixedUpdate for physics updates
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal axis input (A/D)
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical axis input (W/S)

        // Move the spaceship based on input and speed
        spaceshipRigidbody.velocity = new Vector2(horizontalInput * spaceshipSpeed, verticalInput * spaceshipSpeed);
    }
}
