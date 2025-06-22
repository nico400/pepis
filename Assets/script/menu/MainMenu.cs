using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject painelOption;
    [SerializeField] GameObject painelControlle;
    [SerializeField] GameObject GameOptions;
    [SerializeField] getInputsHandler input;

    [SerializeField] GameObject imgGameObj;
    [SerializeField] Image img;
    [SerializeField] Color black;
    [SerializeField] bool transition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        painelOption.SetActive(false);
        painelControlle.SetActive(false);
        GameOptions.SetActive(true);
        transition = false;
        imgGameObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float timing = 0;
        timing += Time.deltaTime;
        float time = 0.74f / timing;

        if (input.exitUiPainel)
        {        
            painelOption.SetActive(false);
            painelControlle.SetActive(false);
            GameOptions.SetActive(true);
        }
        if (transition)
            img.color = Color.Lerp(img.color, black, time * Time.deltaTime);
    }
    public void OpenOptionMenu()
    {
        GameOptions.SetActive(false);
        painelOption.SetActive(true);
    }
    public void PlayOption()
    {
        imgGameObj.SetActive(true);
        StartCoroutine(loadPlay());
        transition = true;
    }
    public void closePainelButton()
    {
        painelOption.SetActive(false);
        GameOptions.SetActive(true);
    }
    public void closeControllePainelButton()
    {
        painelControlle.SetActive(false);
        GameOptions.SetActive(true);
    }
    public void controllePainel()
    {
        GameOptions.SetActive(false);
        painelControlle.SetActive(true);
    }
    IEnumerator loadPlay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Startcutscene");
    }
}
