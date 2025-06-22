using NUnit.Framework.Interfaces;
using UnityEngine;

public class myItem : collectedObj
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!inventaryObj.itemInMyInvetory.Contains(this))
            {
                inventaryObj.itemInMyInvetory.Add(this);
            }

            Destroy(this.gameObject);
        }
    }
}
