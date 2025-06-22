using System.Collections;
using UnityEngine;

public class eventKey : MonoBehaviour
{
    [SerializeField] GameObject camDisable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeObj._Onkey += myEvent;
    }
    private void OnDestroy()
    {
        activeObj._Onkey -= myEvent;
    }

    void myEvent()
    {
        if (this.gameObject != null)
            StartCoroutine(actKey());
    }

    IEnumerator actKey()
    {

        camDisable.SetActive(true);
        yield return new WaitForSeconds(5);
        camDisable.SetActive(false);
        activeObj.stop = true;
    }

}
