using UnityEngine;
using UnityEngine.Splines;

public class plataformSpline : MonoBehaviour
{
    [SerializeField] SplineAnimate animSpline;
    [SerializeField] int StartTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animSpline.Play();
        animSpline.ElapsedTime = StartTime;
    }
}
