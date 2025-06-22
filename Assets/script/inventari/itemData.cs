using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string descriPt;
    public string descriEng;
    public Sprite itemSprite;

    public ItemData(string pt, string eng, Sprite sprite)
    {
        descriPt = pt;
        descriEng = eng;
        itemSprite = sprite;
    }
}