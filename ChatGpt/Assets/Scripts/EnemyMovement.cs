using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed; // Enemy speed
    private bool isMovingLeft = true; // Direction of movement

    void Start()
    {
        // Generate a random speed between 3 and 5
        speed = Random.Range(3f, 5f);
    }

    void Update()
    {
        // Move the enemy
        Move();

        // Check if the enemy has left the camera view on the left side
        if (IsOutsideCameraView() && isMovingLeft)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        // Move the enemy towards the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    bool IsOutsideCameraView()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        return screenPos.x < 0;
    }
}
