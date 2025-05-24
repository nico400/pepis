using UnityEngine;
using System.Collections;

public class launchBall : MonoBehaviour
{
    public static launchBall instance;
    [SerializeField] Transform localPosObj;
    [SerializeField] Rigidbody rb;
    public bool Grab { get; private set; }
    public bool iCanLaunch { get; private set; }
    public bool aimEnable { get; private set; }
    public GameObject objGrab;

    [SerializeField] LineRenderer line;
    [SerializeField] int countPostions = 15;
    [SerializeField] float timeOfTheFlight;
    bool launc;

    public delegate void OnDestryObj();
    public static event OnDestryObj _OndestroyObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        aimEnable = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moviment.instance.interactive && objGrab != null && moviment.instance.canHold)
        {
            StartCoroutine(getBall());
        }
        if (iCanLaunch)
        {
            StartCoroutine(launBall(localPosObj.forward * 15 + localPosObj.up * 4));            
        }
    }
    IEnumerator getBall()
    {
        Grab = true;
        moviment.instance.canHold = false;

        while (Grab)
        {
            //get ball

            moviment.instance.canJump = false;
            objGrab.GetComponent<Rigidbody>().useGravity = false;
            objGrab.transform.position = localPosObj.position;
            objGrab.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            objGrab.transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);

            if (!moviment.instance.interactive)
                iCanLaunch = true;

            yield return null;
        }
        
    }
    IEnumerator launBall(Vector3 velocity)
    {
        
        if (moviment.instance.holdObj)
        {
            //draw trajectory
            line.enabled = true;
            float timeStep = timeOfTheFlight / countPostions;
            Vector3[] lineRenderPoints = calculateTrajectory(localPosObj.position, velocity, timeStep);
            line.positionCount = countPostions;
            line.SetPositions(lineRenderPoints);
            moviment.instance.canMove = false;
            aimEnable = true;
            launc = true;
        }
        else
        {
            line.enabled = false;
            moviment.instance.canJump = true;
            moviment.instance.canHold = true;
            if (launc)
            {

                Grab = false;
                moviment.instance.canMove = true;
                objGrab.GetComponent<Rigidbody>().useGravity = true;
                objGrab.GetComponent<Rigidbody>().linearVelocity = velocity;
                moviment.instance.canMove = true;
                aimEnable = false;
                launc = false;
                iCanLaunch = false;           
            }
        }

        yield return null;
    }
    Vector3[] calculateTrajectory(Vector3 startPoint, Vector3 velocity, float Time)
    {
        Vector3[] lineRenderPoints = new Vector3[countPostions];
        lineRenderPoints[0] = startPoint;

        for (int i = 1; i < countPostions; i++)
        {
            float timeOffset = Time * i;
            Vector3 progressBeforeGravity = velocity * timeOffset;
            Vector3 gravityOffset = Vector3.up * -0.5f * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPoint = startPoint + progressBeforeGravity - gravityOffset;
            lineRenderPoints[i] = newPoint;

        }

        return lineRenderPoints;
    }
}
