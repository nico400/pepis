using UnityEngine;

public class laserBounce : MonoBehaviour
{
    [SerializeField] int maxBounce;
    [SerializeField] LineRenderer laser;
    [SerializeField] Transform startLaser;
    [SerializeField] LayerMask layerMirror;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.SetPosition(0, startLaser.position);
        laser.positionCount = maxBounce;
    }

    // Update is called once per frame
    void Update()
    {
        castLaser(startLaser.position, startLaser.forward);

    }
    void castLaser(Vector3 pos, Vector3 dir)
    {
        laser.SetPosition(0, startLaser.position);

        for (int i = 0; i < maxBounce; i++)
        {
            Ray ray = new Ray(pos, dir);
            RaycastHit hit;

            if (Physics.Raycast( ray, out hit, 500, layerMirror))
            {
                pos = hit.point;
                dir = Vector3.Reflect( dir, hit.normal );

                if (i < maxBounce - 1)
                {
                    Debug.DrawRay(pos, dir, Color.red);
                    laser.SetPosition(i + 1, hit.point);
                }               
            
            }else
            {
                if (i < maxBounce - 1)
                {
                    laser.SetPosition(i + 1, ray.GetPoint(300));
                }
            }
        }
    }
}
