using UnityEngine;

public class colectedBiscoito : MonoBehaviour
{
    float rotateValue;

    private void Update()
    {
        rotateValue = Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            transform.position = hit.point + Vector3.up * 2f;
        }
        transform.Rotate(new Vector3(0, 0, 1), rotateValue * 25);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
