using UnityEngine;
using TMPro; // For TextMeshPro elements
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance for easy access

    private int score = 0; // Player's score

    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI element displaying score

    void Awake()
    {
        instance = this; // Set singleton instance
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString(); // Update score text

        if (score >= 100)
        {
            // Load Win scene
            SceneManager.LoadScene("Win");
        }
    }
}
