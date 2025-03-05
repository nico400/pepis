using UnityEngine;

public class rotatePlayer : MonoBehaviour
{
    [SerializeField] float speedRotate;
    [SerializeField] float speedRotateNormal;

    // Update is called once per frame
    void Update()
    {
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
