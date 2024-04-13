using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) // Detect collisions (adjust if needed)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerProjectile") // Check for projectile collision
        {
            // Call GameManager to update score
            GameManager.instance.AddScore(5);
            Destroy(gameObject); // Destroy enemy on collision
        }
    }
}
