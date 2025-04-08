using UnityEngine;

public class plataformFollow : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    void Update()
    {
        transform.position = followTarget.position;
    }
}
