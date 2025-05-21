using UnityEngine;

public class pushPull : MonoBehaviour
{
    [SerializeField] CharacterController objPush;
    [SerializeField] detectedPoints pathToUseThisObj;

    [SerializeField] Transform player;
    [SerializeField] bool canPush;
    [SerializeField] LayerMask ground;

    Vector3 dirToPush;
    Vector3 dirToPlayer;

    Vector3 positionAdjust;
    Vector3 movimentDir;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, -transform.up, out hit, 3, ground))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
            return;

        directionToPushObj();
        positionToPush();

        if (canPush)
        {
            objPush.Move(movimentDir * Time.deltaTime * 2);

            if(pathToUseThisObj.dotLimit > pathToUseThisObj.dirPoints.magnitude)
                objPush.Move(-pathToUseThisObj.dirPoints.normalized * Time.deltaTime * 2);
            if(pathToUseThisObj.dotLimit < 0)
                objPush.Move(pathToUseThisObj.dirPoints.normalized * Time.deltaTime * 2);
        }
    }

    void directionToPushObj()
    {
        dirToPlayer = (player.position - transform.position).normalized;
        dirToPlayer.y = 0;
        float angle = Vector3.SignedAngle(transform.forward, dirToPlayer, transform.up);

        Debug.DrawRay(player.position, dirToPlayer, Color.red);

        if (angle < 45 && angle > -45)
        {
            dirToPush = transform.position + transform.forward * 1.5f;
            movimentDir = moviment.instance.dirMove.y * pathToUseThisObj.dirPoints.normalized * -1;
        }
        else if (angle > 135 || angle < -135)
        {
            dirToPush = transform.position + transform.forward * -1.5f;
            movimentDir = (moviment.instance.dirMove.y * pathToUseThisObj.dirPoints.normalized);
        }
    }
    void positionToPush()
    {
        //pussh in pull interactive
        if (moviment.instance.holdObj && moviment.instance.canHold)
        {
            canPush = true;
        }
        else if (!moviment.instance.holdObj || !moviment.instance.canHold)
        {
            canPush = false;
        }

        if (canPush)
        {
            player.position = dirToPush;
            player.rotation = Quaternion.LookRotation(-dirToPlayer, player.transform.up);
            moviment.instance.canMove = false;
        }
        else
        {
            moviment.instance.canMove = true;
        }
    }
}
