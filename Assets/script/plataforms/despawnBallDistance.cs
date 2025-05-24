using System.Collections;
using UnityEngine;

public class despawnBallDistance : MonoBehaviour
{
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            Destroy(collision.gameObject);           
        }    
    }
}
