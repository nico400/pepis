using System.Collections;
using UnityEngine;

public class movingPlataform : MonoBehaviour
{
    [SerializeField] Transform PointToMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            other.gameObject.transform.parent = this.transform;
            StartCoroutine(moving());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            other.gameObject.transform.parent = null;
        }
    }
    IEnumerator moving()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, PointToMove.position, .25f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, PointToMove.rotation, .25f * Time.deltaTime);
            yield return null;
        }       
    }
}
