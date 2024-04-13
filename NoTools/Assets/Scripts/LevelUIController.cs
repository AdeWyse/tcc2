using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUIController : MonoBehaviour
{
    public PlayerController player;

    public TextMeshProUGUI lifeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }

    private void UpdateLife()
    {
        lifeText.text = player.life.ToString();
    }
}
