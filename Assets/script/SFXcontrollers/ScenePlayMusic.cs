using UnityEngine;

public class ScenePlayMusic : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayCurrentClip();
    }

    void PlayCurrentClip()
    {
        audioSource.clip = clips[currentIndex];
        audioSource.Play();
        Invoke("PlayNextTrack", audioSource.clip.length);
    }

    void PlayNextTrack()
    {
        audioSource.Stop();
        currentIndex = (currentIndex + 1) % clips.Length;
        PlayCurrentClip();
    }
}
