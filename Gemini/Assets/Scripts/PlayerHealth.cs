using UnityEngine;
using TMPro; // For TextMeshPro elements
using UnityEngine.SceneManagement; // For scene management

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maximum number of player chances
    private int currentHealth; // Current player health
    public TextMeshProUGUI healthText; // Reference to the TextMeshPro UI element displaying health

    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString(); // Update health display
    }

    void OnCollisionEnter2D(Collision2D collision) // Detect collisions with enemies or projectiles
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile") // Check for enemy or projectile tag
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        healthText.text = currentHealth.ToString(); // Update health display

        if (currentHealth <= 0)
        {
            // Load Game Over scene
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver"); // Load the "GameOver" scene by name
    }
}
