using System.Collections;
using UnityEngine;

public class hitPillarColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            MovimentInPillar.Instance.inPillar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            MovimentInPillar.Instance.inPillar = false;
        }
    }

}
