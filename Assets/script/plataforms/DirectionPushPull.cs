using System.Collections;
using UnityEngine;

public class DirectionPushPull : MonoBehaviour
{
    public static DirectionPushPull instance;

    [SerializeField] Transform Player;
    [SerializeField] GameObject objToPush;
    [SerializeField] Transform pointStart;

    [SerializeField] Transform[] pointsToMove;
    [SerializeField] Transform currentPoint;
    public Transform nextPoint { get; private set; }
    public Transform backPoint { get; private set; }

    Vector3 dirToFoward;
    Vector3 dirToBackward;

    public Vector3 backOrFoward_nextPoint {  get; private set; }
    public Vector3 backOrFoward_backPoint { get; private set; }
    public float distance {  get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        objToPush.transform.position = pointStart.position;
        currentPoint = pointStart;
    }

    // Update is called once per frame
    void Update()
    {    
        for (int i = 0; i < pointsToMove.Length; i++)
        {
            //change Currentpoint
            /*distance = Vector3.Distance(pointsToMove[i].position, objToPush.transform.position);
            if (distance < 0.1f)
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
            /*Vector3 directionToPlayer = (Player.position - objToPush.transform.position).normalized;
            if (nextPoint != null)
            {
                dirToFoward = (nextPoint.position - currentPoint.position).normalized;
                //backOrFoward_nextPoint = Vector3.Dot(dirToFoward, directionToPlayer) * dirToFoward;

                backOrFoward_nextPoint = nextPoint.position - currentPoint.position;
                Debug.DrawRay(currentPoint.transform.position + Vector3.up, backOrFoward_nextPoint, Color.blue);
            }   
            if (backPoint != null)
            {
                dirToBackward = (backPoint.position - currentPoint.position).normalized;
                //backOrFoward_backPoint = Vector3.Dot(dirToBackward, directionToPlayer) * dirToBackward;

                backOrFoward_backPoint = backPoint.position - currentPoint.position;
                Debug.DrawRay(currentPoint.transform.position + Vector3.up, backOrFoward_backPoint, Color.blue);
                //print(backOrFoward_backPoint.magnitude);
            }   */         

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
