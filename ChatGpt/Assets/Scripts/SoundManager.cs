using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayImpactSound()
    {
        audioSource.Play();
    }
}
