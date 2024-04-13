using UnityEngine;

public class PlayImpactSound : MonoBehaviour
{
    private GameObject soundManager; // Reference to the SoundManager GameObject
    void Start()
    {
        // Find the SoundManager GameObject in the scene
        soundManager = GameObject.Find("SoundManager");

        // Optional check for finding the SoundManager
        if (soundManager == null)
        {
            Debug.LogError("SoundManager GameObject not found in the scene!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play impact sound on collision (adjust conditions as needed)
  
        if (soundManager != null)
        {
            AudioSource audioSource = soundManager.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play(); // Play the impact sound
            }
        }

    }


}
