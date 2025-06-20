using UnityEngine;

public class laserBounce : MonoBehaviour
{
    [SerializeField] int maxBounce;
    [SerializeField] LineRenderer laser;
    [SerializeField] Transform startLaser;
    [SerializeField] LayerMask layerMirror;

    //collider in point of laser
    Vector3 point;

    //hit cristal
    [SerializeField] LayerMask layerCristal;
    [SerializeField] activedCristal whatCristalIsActived;

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

        Collider[] collInCristal = Physics.OverlapSphere(point, 1.75f, layerCristal);
        if (collInCristal.Length > 0)
        {
            whatCristalIsActived.actived = true;
        }else
        {
            whatCristalIsActived.actived = false;
        }
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
                    laser.SetPosition(i + 1, hit.point);
                }                        
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 500))
                {
                    if(i < maxBounce - 1)
                    laser.SetPosition(i + 1, hit.point);
                    point = hit.point;
                }
                else if (i < maxBounce - 1)
                {
                    laser.SetPosition(i + 1, ray.GetPoint(150));
                    point = Vector3.zero;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(point, 1.75f);
    }
}
