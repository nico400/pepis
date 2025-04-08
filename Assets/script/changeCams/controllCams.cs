using UnityEngine;

public class controllCams : MonoBehaviour
{
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (launchBall.instance.aimEnable)
        {
            //aim
            cam1.gameObject.SetActive (false);
            cam2.gameObject.SetActive (true);
        }else
        {
            cam2.gameObject.SetActive(false);
            cam1.gameObject.SetActive(true);
        }
    }
}
