using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxChances = 3; // Maximum chances the player has
    private int remainingChances; // Remaining chances
    public TextMeshProUGUI chancesText; // TextMeshPro component to display remaining chances

    private void Start()
    {
        remainingChances = maxChances;
        UpdateChancesUI();
    }

    public void TakeDamage()
    {
        remainingChances--;
        UpdateChancesUI();

        if (remainingChances <= 0)
        {
            // Load the GameOver scene
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateChancesUI()
    {
        chancesText.text = remainingChances.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy or enemy projectile
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(); // Reduce chances when colliding with an enemy or enemy projectile
        }
    }
}
