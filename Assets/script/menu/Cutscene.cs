using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class Cutscene : MonoBehaviour
{
    [SerializeField] int countIndex;

    bool isEnglish;

    [SerializeField] GameObject[] img;
    [SerializeField] GameObject[] textP;
    [SerializeField] GameObject[] textE;
    void Start()
    {
        isEnglish = optionTranslate.ChangeLeanguage;

        countIndex = 0;
        img[0].SetActive(true);

        if (isEnglish)
        {
            textE[0].SetActive (true);
            textP[0].SetActive(false);
        }else
        {
            textE[0].SetActive(false);
            textP[0].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            countIndex++;
        }

        if (countIndex < img.Length)
        {
            for (int i = 0; i < img.Length; i++)
            {
                if (i == countIndex)
                {
                    img[i].SetActive(true);
                    if (isEnglish)
                    {
                        textE[i].SetActive(true);
                        textP[i].SetActive(false);
                    }
                    else
                    {
                        textE[i].SetActive(false);
                        textP[i].SetActive(true);
                    }
                }
                else
                {
                    img[i].SetActive(false);
                    textE[i].SetActive(false);
                    textP[i].SetActive(false);
                }
            }
        }else
        {
            SceneManager.LoadScene("Hub");
        }
        
    }
}
