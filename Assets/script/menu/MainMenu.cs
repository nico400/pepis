using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject painelOption;
    [SerializeField] GameObject GameOptions;
    [SerializeField] getInputsHandler input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        painelOption.SetActive(false);
        GameOptions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {   
        if (input.exitUiPainel)
        {        
            painelOption.SetActive(false);
            GameOptions.SetActive(true);
        }
    }
    public void OpenOptionMenu()
    {
        GameOptions.SetActive(false);
        painelOption.SetActive(true);
    }
    public void PlayOption()
    {
        SceneManager.LoadScene("Hub");
    }
}
