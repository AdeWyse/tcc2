using UnityEngine;
using TMPro; // For TextMeshPro elements

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
        // Debug.Log("Score: " + score); // Optional placeholder for debugging
    }
}
