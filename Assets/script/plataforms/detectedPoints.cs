using UnityEngine;

public class detectedPoints : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] pushPull objToUseThisPoints;
    [SerializeField] LayerMask objPushLayer;
    [SerializeField] float distanceToIdentify;
    [SerializeField] Transform player;
    float maxVelue;
    [SerializeField] Transform pointNear;
    // Update is called once per frame
    void Update()
    {
        maxVelue = Mathf.Infinity;
        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(points[i].position, player.position);
            if (distance < maxVelue)
            {
                maxVelue = distance;
                pointNear = points[i];
            }
        }

    }
    public void getPoints()
    {
        objToUseThisPoints.usePoints = points;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawWireSphere(points[i].position, distanceToIdentify);
        }
    }
}
