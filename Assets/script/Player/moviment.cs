using System.Collections;
using UnityEngine;

public class moviment : MonoBehaviour
{
    public static moviment instance;

    [Header("attrib")]
    [SerializeField] float MaxSpeed;
    [SerializeField] float acelSpeed;
    [SerializeField] float decelSpeed;
    [SerializeField] float jumpHeight;

    [Header("components")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Cam;
    [SerializeField] LayerMask ground;
    [SerializeField] getInputsHandler inputsHandler;
    [SerializeField] bool isGround;

    [Header("Interactive")]
    public bool interactive;
    [SerializeField] bool Grab;
    [SerializeField] Transform localPosObj;
    public GameObject objGrab;

    public Vector3 upNormal { get; private set; }
    public Vector3 dirToWalk { get; private set; }
    public Vector2 dirMove { get; private set; }
    public bool jumpInput { get; private set; }

    Vector3 verticalVelocity;
    Vector3 horizontalVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        getInputs();
        upNormal = getNormal();
        isGround = getGround();
        controllerSpeedMax();

        if (interactive && objGrab != null)
        {
            StartCoroutine(getBall());
        }

    }
    void FixedUpdate()
    {
        if (!MovimentInPillar.Instance.inPillar)
        {
            movementPlayer();
            speedcontroller();
            jumpPlayer();
        }
    }
    void getInputs()
    {
        dirMove = inputsHandler.dirXY;
        jumpInput = inputsHandler.jump;
        interactive = inputsHandler.interactived;
    }
    void movementPlayer()
    {
        Vector3 newRight = Vector3.Cross(Cam.forward, upNormal).normalized;
        Vector3 newFoward = Vector3.Cross(newRight, upNormal).normalized;
        dirToWalk = -newFoward * dirMove.y + -newRight * dirMove.x;               
    }
    void jumpPlayer()
    {
        if (jumpInput && isGround)
        {
            float jumpforce = Mathf.Sqrt(2 * 9 * jumpHeight);
            rb.linearVelocity = (Vector3.up * jumpforce) + horizontalVelocity;
        }
    }
    
    void speedcontroller()
    {
        verticalVelocity = Vector3.Project(rb.linearVelocity, upNormal.normalized);
        horizontalVelocity = Vector3.ProjectOnPlane(rb.linearVelocity, upNormal.normalized);
        if (dirMove.magnitude > 0)
        {
            //acelareation
            rb.linearVelocity = Vector3.MoveTowards(horizontalVelocity, dirToWalk * MaxSpeed, acelSpeed * Time.deltaTime) + verticalVelocity;
        }else
        {
            //Decelareation
            rb.linearVelocity = Vector3.MoveTowards(horizontalVelocity, Vector3.zero, decelSpeed * Time.deltaTime) + verticalVelocity;
        }

        if(!isGround)
            //Decelareation
            rb.linearVelocity = Vector3.MoveTowards(horizontalVelocity, dirToWalk *(MaxSpeed / 1.5f), (decelSpeed  / 2) * Time.deltaTime) + verticalVelocity;

    }
    Vector3 getNormal()
    {
        RaycastHit hit;
        Vector3 posOffset = transform.position + transform.up * 0.35f;
        if (Physics.Raycast(posOffset, -transform.up, out hit, 1, ground))
           return hit.normal;
        else
           return Vector3.up;        
    }
    bool getGround()
    {
        RaycastHit hit;
        Vector3 posOffset = transform.position + transform.up * 0.35f;
        if (Physics.Raycast(posOffset, -transform.up, out hit, 0.65f, ground))
            return true;
        else
            return false;
    }
    void controllerSpeedMax()
    {

        if (MaxSpeed > 15)
        {
            MaxSpeed = Mathf.Lerp(MaxSpeed, 15, 0.25f * Time.deltaTime);
        }
        else if (!Grab && MaxSpeed < 15)
        {
            MaxSpeed = 15;
        }
        if (Grab)
        {
            MaxSpeed = 4;
        }
    }
    IEnumerator getBall()
    {
        Grab = !Grab;
        while (Grab)
        {
            objGrab.GetComponent<Rigidbody>().mass = 10;
            objGrab.GetComponent<Rigidbody>().useGravity = false;
            objGrab.transform.position = localPosObj.position;
            objGrab.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            objGrab.transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);

            yield return null;
        }
        if (!Grab)
        {
            objGrab.GetComponent<Rigidbody>().mass = 1;
            objGrab.GetComponent<Rigidbody>().useGravity = true;
            objGrab.GetComponent<Rigidbody>().linearVelocity = objGrab.transform.forward * 10f + objGrab.transform.up * 10f;
            yield return null;
        }
    }
    public float addVelocity(float add, Vector3 dir, bool isLaunch, Vector3 arcPos)
    {
        if (isLaunch)
        {
            StartCoroutine(disableMoviment());
            transform.position = arcPos;
        }
        MaxSpeed = add;
        rb.linearVelocity = dir * MaxSpeed;
        return MaxSpeed;
    }
    IEnumerator disableMoviment()
    {       
        dirToWalk = Vector3.zero;
        yield return new WaitForSecondsRealtime(1);
    }
}
