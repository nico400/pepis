using UnityEngine;

public class PushPullObj : MonoBehaviour
{
    [SerializeField] LayerMask ground;
    [SerializeField] DirectionPushPull _directionPushPull;
    [SerializeField] Transform player;
    [SerializeField] Vector3 pointToPullPush;
    [SerializeField] bool iPullObj;

    private void OnTriggerStay(Collider other)
    {
        Vector3 drToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.SignedAngle(drToPlayer, transform.forward, Vector3.up);
        getPointToObjPush(angleToPlayer);
        holdPushAndPullObj();
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, -transform.up, out hit, 2, ground))
            pointToPullPush.y = hit.point.y;

        /*if (iPullObj)
        {           
            player.position = pointToPullPush;
            player.transform.rotation = Quaternion.LookRotation(-drToPlayer, Vector3.up);



        }*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointToPullPush, 0.3f);
    }
    void getPointToObjPush(float angleToPlayer)
    {
        if (angleToPlayer < 45 && angleToPlayer > -45)
        {
            pointToPullPush = transform.position + transform.forward;
        }
        else if (angleToPlayer > 45 && angleToPlayer < 135)
        {
            pointToPullPush = transform.position + transform.right * -1;
        }
        else if (angleToPlayer > -135 && angleToPlayer < -45)
        {
            pointToPullPush = transform.position + transform.right;
        }
        else if (angleToPlayer > 135 || angleToPlayer < -135)
        {
            pointToPullPush = transform.position + transform.forward * -1;
        }
    }
    void holdPushAndPullObj()
    {
        if (moviment.instance.holdObj && moviment.instance.canHold)
        {
            moviment.instance.canHold = false;
            moviment.instance.canMove = false;
            iPullObj = true;
        }
        else if (!moviment.instance.holdObj)
        {
            moviment.instance.canHold = true;
            moviment.instance.canMove = true;
            iPullObj = false;
        }
    }
}
