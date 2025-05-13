using UnityEngine;

public class DirectionPushPull : MonoBehaviour
{

    [SerializeField] GameObject objToPush;
    [SerializeField] Transform pointStart;

    [SerializeField] Transform[] pointsToMove;
    [SerializeField] Transform currentPoint;

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
                print(pointsToMove[i]);
                //last point look to penults
                pointsToMove[i].LookAt(pointsToMove[i - 1]);
            }
            //change Currentpoint
            float distanceToPoint = Vector3.Distance(pointsToMove[i].position, objToPush.transform.position);
            if (distanceToPoint <= 0)
            {
                currentPoint = pointsToMove[i];
            }

            //direction push or pull
            if (i < pointsToMove.Length - 1)
            {
                Vector3 directionToNewPoint = pointsToMove[i].position - pointsToMove[i + 1].position;
                Vector3 BackOrFowardToPoint
            }
            

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
