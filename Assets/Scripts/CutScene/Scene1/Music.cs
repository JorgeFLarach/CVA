using UnityEngine;

public class Music : MonoBehaviour
{
    // public AudioClip audioClip;
    public AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        // audioSource = GetComponent<AudioSource>();
        // audioSource.clip = audioClip;
        // audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}