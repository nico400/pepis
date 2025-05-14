using UnityEngine;

public class DirectionPushPull : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] GameObject objToPush;
    [SerializeField] Transform pointStart;

    [SerializeField] Transform[] pointsToMove;
    [SerializeField] Transform currentPoint;
    [SerializeField] Transform nextPoint;
    [SerializeField] Transform backPoint;

    Vector3 dirToFoward;
    Vector3 dirToBackward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objToPush.transform.position = pointStart.position;
        currentPoint = pointStart;
    }

    // Update is called once per frame
    void Update()
    {    
        for (int i = 0; i < pointsToMove.Length; i++)
        {
            //look to next point
            if (i < pointsToMove.Length - 1)
            {
                pointsToMove[i].LookAt(pointsToMove[i + 1]);
            }else if(i >= pointsToMove.Length - 1)
            {
                //last point look to penults
                pointsToMove[i].LookAt(pointsToMove[i - 1]);
            }
            //change Currentpoint
            float distanceToPoint = Vector3.Distance(pointsToMove[i].position, objToPush.transform.position);
            if (distanceToPoint <= 0)
            {
                currentPoint = pointsToMove[i];
                if(i == 0)
                {
                    nextPoint = pointsToMove[i + 1];
                    backPoint = null;
                }
                else if (i < pointsToMove.Length - 1)
                {
                    nextPoint = pointsToMove[i + 1];
                    backPoint = pointsToMove[i - 1];
                }else
                {
                    nextPoint = null;
                    backPoint = pointsToMove[i - 1];
                }
            }
            //direction to next and to back
            if(nextPoint != null)
                dirToFoward = (nextPoint.position - currentPoint.position).normalized;
            if(backPoint != null)
                dirToBackward = (backPoint.position - currentPoint.position).normalized;

            Debug.DrawRay(objToPush.transform.position, dirToFoward * 2, Color.blue);
            Debug.DrawRay(objToPush.transform.position, dirToBackward * 2, Color.blue);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < pointsToMove.Length; i++)
        {
            if (i < pointsToMove.Length - 1)
                Gizmos.DrawLine(pointsToMove[i].position, pointsToMove[i+1].position);
        }
    }
}
