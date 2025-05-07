using NUnit.Framework;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] int countIndex;

    [SerializeField] GameObject[] img;
    [SerializeField] GameObject[] text;
    void Start()
    {
        countIndex = 0;
        for (int i = 0; i < img.Length; i++)
        {
            if (i == countIndex)
            {
                img[0].SetActive(true);
                text[0].SetActive(true);
            }
            else
            {
                img[i].SetActive(false);
                text[i].SetActive(false);
            }
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
                    text[i].SetActive(true);
                }
                else
                {
                    img[i].SetActive(false);
                    text[i].SetActive(false);
                }
            }
        }
        
    }
}
