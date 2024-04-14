using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // Background music clip

    private AudioSource audioSource;

    private void Start()
    {
        // Get reference to the AudioSource component on the BackgroundMusic GameObject
        audioSource = GetComponent<AudioSource>();

        // Set background music clip
        audioSource.clip = backgroundMusic;

        // Play background music
        audioSource.Play();

        // Ensure that background music loops
        audioSource.loop = true;
    }
}
