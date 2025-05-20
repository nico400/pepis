using UnityEngine;

public class pushPull : MonoBehaviour
{
    [SerializeField] detectedPoints pathUseThisObjUse;

    public Transform[] usePoints;
    public Transform pointInDown;   

    [SerializeField] Transform player;

    Vector3 dirToPull;
    Vector3 directionToNextPoint;
    Vector3 directionToBackPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathUseThisObjUse.getPoints();
        transform.position = usePoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        directionToPoints();
        print(pointInDown.position);
    }
    void directionToPoints()
    {
        for (int i = 0; i < usePoints.Length; i++)
        {
            //direction to next point
            if (i < usePoints.Length - 1)
            {
                //first to next point
                directionToNextPoint = (usePoints[i + 1].position - usePoints[i].position).normalized;
                Debug.DrawRay(usePoints[i].position + Vector3.up, directionToNextPoint, Color.red);
            }
        }
        for (int i = usePoints.Length - 1; i >= 0; i--)
        {
            if (i > 0)
            {
                directionToBackPoint = (usePoints[i - 1].position - usePoints[i].position).normalized;
                Debug.DrawRay(usePoints[i].position + Vector3.up, directionToBackPoint, Color.blue);
            }
        }
    }
}
