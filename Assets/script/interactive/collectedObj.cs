using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.UI;

public class collectedObj : MonoBehaviour
{
    float rotateValue;
    public string descriPt;
    public string descriEng;
    public GameObject ButtonUiReferring;

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
}
