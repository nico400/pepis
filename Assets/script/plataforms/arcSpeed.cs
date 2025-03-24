
using UnityEngine;

public class arcSpeed : MonoBehaviour
{
    [SerializeField] float addVel; 
    [SerializeField] Transform posPlayer;
    [SerializeField] bool LAUNCH_ARC;
    Vector3 dirToVelocity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Vector3 dirToPlayer = transform.position - posPlayer.position;

            if (LAUNCH_ARC)
                dirToVelocity = transform.forward;
            else
                dirToVelocity = (Vector3.Dot(dirToPlayer, transform.forward) * transform.forward).normalized;

            moviment.instance.addVelocity(addVel, dirToVelocity, LAUNCH_ARC, transform.position);
        }
    }
}
