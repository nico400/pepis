using UnityEngine;

public class rotatePlataformTower : MonoBehaviour
{
    float Angle;
    [SerializeField] Vector3 rotateAxis;
    [SerializeField] float speedRotate;
    void Update()
    {
        Angle = Mathf.PI * Time.deltaTime * speedRotate;
        transform.Rotate(rotateAxis, Angle, Space.Self);
    }
}
