using UnityEngine;

public class controllCams : MonoBehaviour
{
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    //[SerializeField] GameObject camShake;

    void Update()
    {
        if (launchBall.instance.aimEnable)
        {
            //aim
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            //camShake.gameObject.SetActive(false);
        } 
        
        else
        {
            //normal
            cam2.gameObject.SetActive(false);
            cam1.gameObject.SetActive(true);
            //camShake.gameObject.SetActive(false);
        }
    }
}
