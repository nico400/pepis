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

    private void Awake()
    {
        itemInMyInvetory.Clear();
    }

    private void Update()
    {
        

        /*itemDescript = new string[itemInMyInvetory.Count];
        for (int i = 0; i < itemInMyInvetory.Count; i++)
        {
            itemInMyInvetory[i].ButtonUiReferring.SetActive(true);
            itemDescript[i] = itemInMyInvetory[i].descriPt;
        }*/

        for (int i = 0; i < itemInMyInvetory.Count; i++)
        {
            var item = itemInMyInvetory[i];

            item.ButtonUiReferring.SetActive(true);

            Button btn = item.ButtonUiReferring.GetComponent<Button>();

            string descPt = item.descriPt;
            string descEng = item.descriEng;
            btn.onClick.AddListener(() => ShowDescription(descPt, descEng));
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
                break;
            }
        }
    }
    public void ShowDescription(string descriptionPt, string descriptionEng)
    {
        PT.text = descriptionPt;
        ENG.text = descriptionEng;
    }
}
