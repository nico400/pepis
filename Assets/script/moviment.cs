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
    [SerializeField] Vector2 dirMove;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Cam;
    [SerializeField] LayerMask ground;
    [SerializeField] getInputsHandler inputsHandler;
    [SerializeField] bool jumpInput;
    [SerializeField] bool isGround;
    Vector3 verticalVelocity;
    Vector3 horizontalVelocity;


    public Vector3 upNormal { get; private set; }
    public Vector3 dirToWalk { get; private set; }

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
    }
    void FixedUpdate()
    {
        movementPlayer();
        speedcontroller();
        jumpPlayer();
    }
    void getInputs()
    {
        dirMove = inputsHandler.dirXY;
        jumpInput = inputsHandler.jump;
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
            rb.linearVelocity = Vector3.MoveTowards(horizontalVelocity, dirToWalk *(MaxSpeed / 2.5f), decelSpeed * Time.deltaTime) + verticalVelocity;
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
}
