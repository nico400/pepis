using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class moviment : MonoBehaviour
{
    public static moviment instance;

    [Header("attrib")]
    [SerializeField] float MaxSpeed;
    [SerializeField] float acelSpeed;
    [SerializeField] float decelSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float JumpDelay;
    [SerializeField] bool doubleJump;

    [Header("components")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Cam;
    [SerializeField] LayerMask ground;
    [SerializeField] getInputsHandler inputsHandler;

    public bool isGround { get; private set; }

    [Header("Interactive")]
    public Vector3 upNormal { get; private set; }
    public Vector3 dirToWalk { get; private set; }
    public Vector2 dirMove { get; private set; }
    public Vector2 dirMouse { get; private set; }
    public bool jumpInput { get; private set; }
    public bool interactive { get; private set; }
    public bool holdObj { get; private set; }
    
    bool runShift;
    bool runGamepad;

    public bool canHold;
    public bool runing;
    public bool canMove;
    public bool canJump;

    Vector3 verticalVelocity;
    Vector3 horizontalVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        canMove = true;
        canHold = true;
        canJump = true;
    }
    // Update is called once per frame
    void Update()
    {
        getInputs();
        upNormal = getNormal();
        isGround = getGround();
        controllerSpeedMax();
        dirMovementPlayer();
    }
    void FixedUpdate()
    {
        if (MovimentInPillar.Instance.inPillar) return;
        if (MovimentWall.Instance.inWall) return;
        if (!canMove) 
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            return;
        }

        rb.useGravity = true;

        jumpPlayer();    
        speedController();
        
    }
    void getInputs()
    {
        dirMove = inputsHandler.dirXY;
        dirMouse = inputsHandler.mouseXY;
        jumpInput = inputsHandler.jump;
        interactive = inputsHandler.interactived;
        holdObj = inputsHandler.holdOrNot;

        if (dirMove == Vector2.zero)
        {
            //not moving not run
            runShift = false;
            runGamepad = false;
            runing = false;
        }

        if (dirMove != Vector2.zero)
        {
            //moving i can run
            if(inputsHandler.runGamepad)
                runGamepad =! runGamepad;

            runShift = inputsHandler.runShift;

            if (runShift || runGamepad)
                runing = true;
            else
                runing = false;

        }     
    }
    void dirMovementPlayer()
    {
        Vector3 newRight = Vector3.Cross(Cam.forward, upNormal).normalized;
        Vector3 newFoward = Vector3.Cross(newRight, upNormal).normalized;
        dirToWalk = -newFoward * dirMove.y + -newRight * dirMove.x;               
    }
    void jumpPlayer()
    {
        float jumpforce = Mathf.Sqrt(2 * 9 * jumpHeight);

        if (!canJump) return;

        if (isGround && jumpInput)
        {
            rb.linearVelocity = (Vector3.up * jumpforce) + horizontalVelocity;
            JumpDelay = Time.time + 0.3f;
            doubleJump = false;
        }
        else if (!isGround)
        {
            if (jumpInput && !doubleJump && Time.time > JumpDelay)
            {
                doubleJump = true;
                rb.linearVelocity = (Vector3.up * jumpforce) + horizontalVelocity;
            }
        }
    }   
    void speedController()
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
        if (Physics.Raycast(posOffset, -transform.up, out hit, 0.75f, ground))
        {
            return true;
        }
        else
            return false;
    }
    void controllerSpeedMax()
    {

        if (MaxSpeed > 10)
        {
            MaxSpeed = Mathf.Lerp(MaxSpeed, 10, 0.25f * Time.deltaTime);
        }
        else if (!launchBall.instance.Grab && runing)
        {
            MaxSpeed = 10;
        }
        else if (!launchBall.instance.Grab && (MaxSpeed < 7 || MaxSpeed > 7) && !runing)
        {
            MaxSpeed = 5;
        }
        if (launchBall.instance.Grab)
        {
            MaxSpeed = 4;
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
    public bool isGrab(bool _isGrab)
    {
        return _isGrab;
    }

}
