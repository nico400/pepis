using UnityEngine;

public class PushPullObj : MonoBehaviour
{
    [SerializeField] DirectionPushPull _directionPushPull;
    [SerializeField] float nextPointBackOrFoward;
    [SerializeField] float backPointBackOrFoward;

    [SerializeField] Vector3 pointToPullPush;

    // Update is called once per frame
    void Update()
    {
        
        nextPointBackOrFoward = _directionPushPull.backOrFoward_nextPoint;
        backPointBackOrFoward = _directionPushPull.backOrFoward_backPoint;

        if (nextPointBackOrFoward > 0.8f)
        {
            pointToPullPush = transform.position + transform.forward;
        }
        else if(nextPointBackOrFoward < -0.8f)
        {
            pointToPullPush = transform.position + (transform.forward * -1);
        }
        if (backPointBackOrFoward > 0.8f)
        {
            pointToPullPush = transform.position + transform.right;
        }
        else if (backPointBackOrFoward < -0.8f)
        {
            pointToPullPush = transform.position + (transform.right * -1);
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
