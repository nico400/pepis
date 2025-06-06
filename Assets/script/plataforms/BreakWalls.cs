using UnityEngine;

public class BreakWalls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball") && !launchBall.instance.Grab)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }           
    }
}
