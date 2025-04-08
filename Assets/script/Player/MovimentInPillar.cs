using UnityEngine;
using System.Collections;
public class MovimentInPillar : MonoBehaviour
{
    public static MovimentInPillar Instance;

    [Header("pillar mov")]
    [SerializeField] Transform pillarCurrent;
    public bool inPillar;
    [SerializeField] float radiusSphereColl;
    [SerializeField] LayerMask pillarLayer;
    [SerializeField] Rigidbody rb;

    public Vector3 dirToPillar { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (inPillar)
        {
            rb.useGravity = false;
            movimentPillar();
        }else
        {

            pillarCurrent = null;
        }

    }
    void movimentPillar()
    {
        rb.linearVelocity = Vector3.zero;
        RaycastHit hit;
        Collider[] collPillar = Physics.OverlapSphere(transform.position, radiusSphereColl, pillarLayer);

        if (collPillar.Length > 0)
            pillarCurrent = collPillar[0].transform;

        if (pillarCurrent != null)
        {
            Vector3 locationPillar = new Vector3(pillarCurrent.position.x, transform.position.y, pillarCurrent.position.z);
            dirToPillar = (locationPillar - transform.position).normalized;
            if (Physics.Raycast(transform.position, dirToPillar, out hit, 1, pillarLayer))
            {
                Vector3 newRight = Vector3.Cross(dirToPillar, moviment.instance.upNormal).normalized;
                Vector3 dirTorotate = -newRight * moviment.instance.dirMove.x;
                Vector3 dirToUpAndDown = transform.up * moviment.instance.dirMove.y;

                transform.position = Vector3.Lerp(transform.position, hit.point, 2 * Time.deltaTime);
                rb.linearVelocity = (dirToUpAndDown * 3) + (dirTorotate * 3f);
            }
        }
       
        if (moviment.instance.jumpInput)
        {
            StartCoroutine(jumpInPillar());
        }
    }
    IEnumerator jumpInPillar()
    {
        rb.linearVelocity = (-transform.forward * 8 + transform.up * 8);
        inPillar = false;      
        yield return null;
    }
}
