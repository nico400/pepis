using UnityEngine;

public class grabbBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask ground;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            launchBall.instance.objGrab = this.gameObject;
        }
        if (other.gameObject.tag.Equals(ground))
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            launchBall.instance.objGrab = null;
        }
    }
    public void Init(Vector3 veolocity)
    {
        rb.AddForce(veolocity, ForceMode.Impulse);
    }
}
