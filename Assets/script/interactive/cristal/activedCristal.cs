using UnityEngine;

public class activedCristal : MonoBehaviour
{
    public bool actived;
    bool stop;
    [SerializeField] AudioSource SFX;

    private void Update()
    {
        if (actived && !SFX.isPlaying && !stop)
        {
            SFX.Play();
            stop = true;
        }
        else if(!actived)
        {
            stop = false;
        }
    }
}
