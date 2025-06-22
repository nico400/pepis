using NUnit;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class inventaryObj : MonoBehaviour
{
    public static List<myItem> itemInMyInvetory = new List<myItem>();

    [SerializeField] Image imgInUI;
    [SerializeField] Button BTN_ImgItem;

    [SerializeField] TextMeshProUGUI PT;
    [SerializeField] TextMeshProUGUI ENG;

    [SerializeField] string[] itemDescript;

    [SerializeField] GameObject raçaoBT;
    [SerializeField] GameObject brinqBT;
    [SerializeField] GameObject cartaoBT;
    [SerializeField] GameObject fotoBT;

    public void Update()
    {
       
        for (int i = 0; i < itemInMyInvetory.Count; i++)
        {
            if (itemInMyInvetory[i] == null)
                print(itemInMyInvetory[i] + ": null");
            else
            {
                if (itemInMyInvetory[i].type == collectedObj.myType.racao)
                    itemInMyInvetory[i].ButtonUiReferring = raçaoBT;

                if (itemInMyInvetory[i].type == collectedObj.myType.pneu)
                    itemInMyInvetory[i].ButtonUiReferring = brinqBT;

                if (itemInMyInvetory[i].type == collectedObj.myType.cartao)
                    itemInMyInvetory[i].ButtonUiReferring = cartaoBT;

                if (itemInMyInvetory[i].type == collectedObj.myType.foto)
                    itemInMyInvetory[i].ButtonUiReferring = fotoBT;

                itemInMyInvetory[i].ButtonUiReferring.SetActive(true);
            }
        }
    }
    public void changeToMyImg(Button btn)
    {
        BTN_ImgItem = btn;
        imgInUI.sprite = BTN_ImgItem.image.sprite;

        foreach (var item in itemInMyInvetory)
        {
            if (item.ButtonUiReferring == btn.gameObject)
            {
                PT.text = item.descriPt;
                ENG.text = item.descriEng;
                break;
            }
        }
    }
}