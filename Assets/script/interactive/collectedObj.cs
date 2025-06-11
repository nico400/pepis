using UnityEngine;

public class collectedObj : MonoBehaviour
{
    float rotateValue;
    public ItemCreator item;

    public delegate void OnColecterObj();
    public static event OnColecterObj _colecterObj;

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
            _colecterObj?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
