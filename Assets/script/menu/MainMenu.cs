using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject painelOption;
    [SerializeField] GameObject GameOptions;
    [SerializeField] getInputsHandler input;

    [SerializeField] GameObject img;
    [SerializeField] Color black;
    [SerializeField] Color invisible;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        painelOption.SetActive(false);
        GameOptions.SetActive(true);

        img.SetActive(false);
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
        img.SetActive(true);
        //img.GetComponent(Image).color = Color.Lerp(imgTransition.color, black, 0.55f * Time.deltaTime);
        StartCoroutine(loadPlay());
    }

    IEnumerator loadPlay()
    {       
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Startcutscene");
    }
}
