using UnityEngine;

public class rotatePlataformTower : MonoBehaviour
{
    float Angle;
    void Update()
    {
        Angle += Mathf.PI * Time.deltaTime * 3.5f;
        transform.rotation = Quaternion.AngleAxis(Angle, transform.up);
    }
}
