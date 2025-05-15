using UnityEngine;

public class PushPullObj : MonoBehaviour
{
    [SerializeField] DirectionPushPull _directionPushPull;
    [SerializeField] Transform player;

    [SerializeField] Vector3 pointToPullPush;
    

    // Update is called once per frame
    void Update()
    {
        
        Vector3 drToPlayer = (player.position - transform.position).normalized;
        drToPlayer.y = 0;
        float angleToPlayer = Vector3.SignedAngle(drToPlayer, transform.forward,Vector3.up);
       /// print(angleToPlayer);

        if (angleToPlayer < 45 && angleToPlayer > -45)
        {
            print("frente");
        }else if (angleToPlayer > 45 && angleToPlayer < 135)
        {
            print("esquerda");
        }else if (angleToPlayer > 135 && angleToPlayer < -135)
        {
            print("baixo");
        }else if (angleToPlayer < -135 && angleToPlayer < - 45)
        {
            print("direita");
        }

    }
    private void OnTriggerStay(Collider other)
    {
        


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointToPullPush, 0.3f);
    }
}
