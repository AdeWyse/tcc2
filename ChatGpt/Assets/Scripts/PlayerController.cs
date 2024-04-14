using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of the spaceship
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = direction * speed;
    }
}
