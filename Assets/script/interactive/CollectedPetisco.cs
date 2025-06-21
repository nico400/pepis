using UnityEngine;

public class CollectedPetisco : collectedObj
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            moviment.points++;
            Destroy(this.gameObject);
        }
    }
}
