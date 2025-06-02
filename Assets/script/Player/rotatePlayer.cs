using UnityEngine;
using UnityEngine.InputSystem;

public class rotatePlayer : MonoBehaviour
{
    [SerializeField] float speedRotate;
    [SerializeField] float speedRotateNormal;

    [Header("rotate aim config")]
    [SerializeField] Transform originLaunchBallPoint;
    [SerializeField] float sencX;
    [SerializeField] float sencY;

    [SerializeField] float mouseY;

    // Update is called once per frame
    void Update()
    {
        if (MovimentInPillar.Instance.inPillar)
        {
            Quaternion rotPillar = Quaternion.LookRotation(MovimentInPillar.Instance.dirToPillar, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotPillar, speedRotate * Time.deltaTime);
            return;
        }
        if (launchBall.instance.aimEnable)
        {
            transform.rotation = Quaternion.Euler(0, moviment.instance.dirMouse.x * sencX, 0) * transform.rotation;
           
            if (originLaunchBallPoint.localRotation.x < -.3f)
            {
                originLaunchBallPoint.localRotation = Quaternion.Euler( sencY, 0, 0) * originLaunchBallPoint.localRotation;
            }
            else if(originLaunchBallPoint.localRotation.x > .3f)
            {
                originLaunchBallPoint.localRotation = Quaternion.Euler( -sencY, 0, 0) * originLaunchBallPoint.localRotation;
            }
            else
            {
                originLaunchBallPoint.localRotation = Quaternion.Euler(-moviment.instance.dirMouse.y * sencY, 0, 0) * originLaunchBallPoint.localRotation;
            }
            return;
        }

        Vector3 rotate = moviment.instance.dirToWalk;
        Vector3 normal =  moviment.instance.upNormal;
        //rotate to normal ground
        Quaternion rotateNormal = Quaternion.FromToRotation(transform.up, normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateNormal, speedRotateNormal * Time.deltaTime);

        if (rotate == Vector3.zero) return;
        //rotate to dir move
        Quaternion rot = Quaternion.LookRotation(rotate, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speedRotate * Time.deltaTime);
    }
}
