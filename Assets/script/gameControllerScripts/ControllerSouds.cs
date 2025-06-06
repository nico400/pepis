using UnityEngine;
using UnityEngine.UI;

public class ControllerSouds : MonoBehaviour
{
    [SerializeField] AudioSource musicLevel;
    [SerializeField] Slider musicVolumeInGame;
    [SerializeField] Slider inMenu;

    [SerializeField] float value;

    private void Start()
    {
        
    }

    void Update()
    {
        if (musicVolumeInGame != null)
        {
            value = musicVolumeInGame.value;
            musicLevel.volume = value;
        }
        if (inMenu != null)
        {
            value = inMenu.value;
            musicLevel.volume = value;
        }
    }
}
