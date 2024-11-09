using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private static BackgroundMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.parent.gameObject); // Parent GameObject is not destroyed
            audioSource = GetComponent<AudioSource>();
            audioSource.Play(); // Start playing the background music
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}
