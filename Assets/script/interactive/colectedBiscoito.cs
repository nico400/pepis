using UnityEngine;

public class colectedBiscoito : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
