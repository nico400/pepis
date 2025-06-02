using UnityEngine;

public class ScenePlayMusic : MonoBehaviour
{
    [SerializeField] AudioClip musicOne;
    [SerializeField] AudioClip musicTwo;

    [SerializeField] AudioSource playingMuisic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playingMuisic.clip = musicOne;
        playingMuisic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("playingNextMusic", playingMuisic.clip.length);
    }

    void playingNextMusic()
    {
        playingMuisic.Stop();
        if (playingMuisic.clip == musicOne)
        {
            playingMuisic.clip = musicTwo;
        }else if (playingMuisic.clip == musicTwo)
        {
            playingMuisic.clip = musicOne;
        }
        playingMuisic.Play();
    }

}
