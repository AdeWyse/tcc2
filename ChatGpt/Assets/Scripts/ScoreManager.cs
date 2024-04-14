using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // TextMeshPro component to display player's score

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
