using UnityEngine;
using System.Collections;

public class MovimentWall : MonoBehaviour
{
    public static MovimentWall Instance;

    public bool inWall;
    [SerializeField] LayerMask Viny;
    [SerializeField] Rigidbody rb;

    Vector3 originRay;
    Vector3 point;
    [SerializeField] Vector3 offsetOrigin;
    public Vector3 dirToWallNormal { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //detect wall (vine)
        RaycastHit hit;
        originRay = (transform.forward * offsetOrigin.z + transform.up * offsetOrigin.y + transform.right * offsetOrigin.x) + transform.position;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3, Viny))
        {
            inWall = true;
            rb.linearVelocity = Vector3.zero;
            rb.useGravity = false;

            //moviment In wall
            dirToWallNormal = -hit.normal;
            transform.position = hit.point;
            Vector3 dirMovi = transform.right * moviment.instance.dirMove.x + transform.up * moviment.instance.dirMove.y;
            rb.linearVelocity = dirMovi.normalized * 2;

            if (moviment.instance.jumpInput)
            {
                StartCoroutine(jumpInPillar());
            }
        }else
        {
            inWall = false;
        }

    }

    IEnumerator jumpInPillar()
    {
        rb.linearVelocity = (-transform.forward * 18 + transform.up * 8);
        inWall = false;
        yield return null;
    }
}
