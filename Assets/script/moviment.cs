using UnityEngine;

public class moviment : MonoBehaviour
{
    [Header("attrib")]
    [SerializeField] float currentSpeed;
    [SerializeField] float acelSpeed;
    [SerializeField] float decelSpeed;

    [Header("components")]
    [SerializeField] Vector2 dirMove;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Cam;
    [SerializeField] LayerMask ground;
    [SerializeField] Vector3 normal;
    [SerializeField] getInputsHandler inputsHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        getInputs();
        normal = getNormal();
    }
    void FixedUpdate()
    {
        movementPlayer();
    }
    void getInputs()
    {
        dirMove = inputsHandler.dirXY;
    }
    void movementPlayer()
    {
        Vector3 newRight = Vector3.Cross(Cam.forward, normal).normalized;
        Vector3 newFoward = Vector3.Cross(newRight, normal).normalized;
        Vector3 dirToWalk = -newFoward * dirMove.y + -newRight * dirMove.x;
        Vector3 verticalVelocity = Vector3.Project(rb.linearVelocity, normal);

        rb.linearVelocity = dirToWalk * currentSpeed + verticalVelocity;
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
}
