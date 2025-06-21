using UnityEngine;

public class myItem : collectedObj
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            inventaryObj.itemInMyInvetory.Add(this);
            Destroy(this.gameObject);
        }
    }  
}
