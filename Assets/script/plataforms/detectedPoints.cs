using UnityEngine;

public class detectedPoints : MonoBehaviour
{
    [SerializeField] Transform startPoints;
    [SerializeField] Transform endPoints;
    [SerializeField] Transform objPush;
    public float dotLimit { get; private set; }
    public Vector3 dirPoints { get; private set; }
    private void Start()
    {
        startPoints.LookAt(endPoints.position);

        objPush.position = startPoints.position;
        objPush.rotation = startPoints.rotation;
    }

    void Update()
    {

        dirPoints = (endPoints.position - startPoints.position);
        Vector3 dirStartPointToObjPush = (objPush.position - startPoints.position);
        dotLimit = Vector3.Dot(dirPoints.normalized, dirStartPointToObjPush);

    }
}
