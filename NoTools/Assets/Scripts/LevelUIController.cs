using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUIController : MonoBehaviour
{
    public PlayerController player;

    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI pointsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
        UpdatePoints();
    }

    private void UpdateLife()
    {
        lifeText.text = player.life.ToString();
    }

    private void UpdatePoints()
    {
        pointsText.text = player.points.ToString();
    }
}
