using System.Collections.Generic;
using UnityEngine;

public class optionTranslate : MonoBehaviour
{
    public static bool ChangeLeanguage;
    [SerializeField] List<GameObject> TextPort = new List<GameObject>();
    [SerializeField] List<GameObject> TextEnglish = new List<GameObject>();

    private void Update()
    {
        if (TextEnglish.Count <= 0 && TextPort.Count <= 0)
            return;

        if (ChangeLeanguage)
        {
            for (int i = 0; i < TextEnglish.Count; i ++)
            {
                TextEnglish[i].SetActive(true);               
            }
            for (int i = 0; i < TextPort.Count; i++)
            {
                TextPort[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < TextEnglish.Count; i++)
            {
                TextEnglish[i].SetActive(false);
            }
            for (int i = 0; i < TextPort.Count; i++)
            {
                TextPort[i].SetActive(true);
            }
        }
            

    }

    public void English()
    {
        ChangeLeanguage = true;
    }
    public void Portugues()
    {
        ChangeLeanguage = false;
    }
}
