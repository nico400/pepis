using NUnit.Framework.Interfaces;
using UnityEngine;

public class myItem : collectedObj
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            inventaryObj.itemInMyInvetory.Add(this);
            this.gameObject.SetActive(false);
        }
    }
}
