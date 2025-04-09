using UnityEngine;

public class BreakWalls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }           
    }
}
