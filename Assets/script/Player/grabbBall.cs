using UnityEngine;

public class grabbBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask ground;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (moviment.instance.interactive)
            {
                moviment.instance.objGrab = this.gameObject;
            }
        }
    }
}
