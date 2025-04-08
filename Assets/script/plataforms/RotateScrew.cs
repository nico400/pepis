using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RotateScrew : MonoBehaviour
{
    [SerializeField] int myId;

    [SerializeField] Vector3 rotateOrigin;
    [SerializeField] Vector3 rotateDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartRotateScrew.OnRotateScrew += startRotate;
    }
    void startRotate(int id)
    {
        if (this == null) return;

        if(id == this.myId)
            StartCoroutine(rotate());
    }
    IEnumerator rotate()
    {
        float startTime = 0;

        do
        {
            startTime += Time.deltaTime;
            print(startTime);

            if (startTime <= 6)
            {
                Quaternion newRot = Quaternion.Euler(rotateDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime);
            }
            else
            {
                Quaternion newRot = Quaternion.Euler(rotateOrigin);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime);
                if (startTime >= 12)
                    break;
            }

            yield return null;

        } while (true);
    }
}
