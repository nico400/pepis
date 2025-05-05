using UnityEngine;

public class animaionController : MonoBehaviour
{
    [SerializeField] float moving;
    [SerializeField] bool isRun;
    [SerializeField] Animator anim;
    // Update is called once per frame
    void Update()
    {
        moving = moviment.instance.dirMove.magnitude;
        isRun = moviment.instance.runing;

        anim.SetBool("Runing", isRun);
        anim.SetFloat("isMove", moving);
    }
}
