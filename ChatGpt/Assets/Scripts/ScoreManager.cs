using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int maxScore = 100; // Maximum score needed to win
    private int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // TextMeshPro component to display player's score

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();

        // Check if the player has reached the maximum score
        if (score >= maxScore)
        {
            // Load the win scene
            SceneManager.LoadScene("Win");
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
