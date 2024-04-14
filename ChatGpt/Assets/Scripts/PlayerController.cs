using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of the spaceship
    private Rigidbody2D rb;
    private float minX; // Minimum X position
    private float minY; // Minimum Y position
    private float maxY; // Maximum Y position
    private float padding = 0.5f; // Additional padding to prevent sprite from going out of the screen

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate the movement bounds with padding
        Camera mainCamera = Camera.main;
        minX = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        minY = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - padding;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = direction * speed;

        // Confine player's movement within the specified bounds
        float clampedX = Mathf.Clamp(transform.position.x, minX, 0);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(clampedX, clampedY);
    }
}
