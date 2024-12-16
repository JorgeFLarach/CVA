using UnityEngine;

public class Source : MonoBehaviour
{
    // public AudioClip audioClip;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // public void PlayMusic()
    // {
    //     if (audioSource.isPlaying) return;
    //     audioSource.Play();
    // }

    // public void StopMusic()
    // {
    //     audioSource.Stop();
    // }
}