using Unity.VisualScripting;
using UnityEngine;

public class plataformRotateLaser : MonoBehaviour
{

    [SerializeField] activedCristal cristalActivated;
    [SerializeField] float time;
    [SerializeField] float speedRot;

    [SerializeField] bool stopMoving;

    bool up;

    float maxValueRotate = 180;
    float minValueRotate = 0;

    float maxValueUp = 16.2f;
    float maxValueDown = -17.80859f;

    float distanceMove;
    float distanceRot;

    void Update()
    {
        distanceMove = maxValueUp - maxValueDown;
        float speedMove = ( distanceMove * time ) / 2;

        speedMove = Mathf.Abs( speedMove );

        up = cristalActivated.actived;
        if (up)
        {
            if (transform.position.y <= maxValueUp)
            {
                transform.position += transform.forward * speedMove * Time.deltaTime;
                Quaternion rotateTo = Quaternion.Euler(-90, 0, 180);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, speedRot * Time.deltaTime);
            }   
            
        }else
        {
            if (transform.position.y >= maxValueDown)
            {
                transform.position += -transform.forward * speedMove * Time.deltaTime;
                Quaternion rotateTo = Quaternion.Euler(-90, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, speedRot * Time.deltaTime);
            }
        }
    }
}
