using System.Collections.Generic;
using UnityEngine;

public class keysRuns : MonoBehaviour
{
    [SerializeField] List<GameObject> points = new List<GameObject>();
    [SerializeField] Transform nextPoint;
    [SerializeField] float speedToNewPoint;
    [SerializeField] Transform player;
    [SerializeField] bool outpace;

    Vector3 dirToMove;
    [SerializeField] Vector3 PointGhost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dirToMove = Vector3.zero;
        transform.position = points[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!outpace)
        {
            for (int i = 0; i < points.Count; i++)
            {
                float distanceToNewPoint = Vector3.Distance(points[i].transform.position, transform.position);
                //new point to foward
                if (distanceToNewPoint <= 5f)
                {
                    if (i >= points.Count - 1)
                    {
                        nextPoint = points[0].transform;
                        PointGhost = points[0].transform.position;
                    }
                    else
                    {
                        nextPoint = points[i + 1].transform;
                        PointGhost = points[i + 1].transform.position;
                    }
                }
            }
        }
        else if (outpace)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                float distanceToNewPoint = Vector3.Distance(points[i].transform.position, transform.position);
                //new point to back
                if (distanceToNewPoint <= 5f)
                {
                    if (i == 0)
                    {
                        nextPoint = points[points.Count - 1].transform;
                        PointGhost = points[i + 1].transform.position;
                    }
                    else
                    {
                        nextPoint = points[i - 1].transform;
                        if (i == points.Count - 1)
                        {
                            PointGhost = points[0].transform.position;
                        }
                        else if (i <= points.Count - 1)
                        {
                            PointGhost = points[i + 1].transform.position;
                        }
                    }
                }
            }
        }

        Vector3 dirToNewPoint = (nextPoint.position - transform.position).normalized;
        dirToMove = Vector3.Slerp(dirToMove, dirToNewPoint, Time.deltaTime);        
        Quaternion lookToNewPoint = Quaternion.LookRotation(dirToMove, transform.up);
        transform.rotation = lookToNewPoint;
        transform.position += dirToMove * speedToNewPoint * Time.deltaTime;

        //change dir to points
        Vector3 pointPredict = (PointGhost - transform.position).normalized;
        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        float backOrFront = Vector3.Dot(pointPredict, dirToPlayer);
        if (backOrFront > 0)
            outpace = true;
        else if (backOrFront < 0)
            outpace = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < points.Count; i++)
        {
            if (i >= points.Count - 1)
            {
                Gizmos.DrawLine(points[points.Count - 1].transform.position, points[0].transform.position);
            }
            else
            {
                Gizmos.DrawLine(points[i].transform.position, points[i + 1].transform.position);
            }           
        }
    }
}
