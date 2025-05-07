using UnityEngine;

public class animaionController : MonoBehaviour
{
    [SerializeField] float moving;
    [SerializeField] bool isRun;
    [SerializeField] bool isground;
    [SerializeField] bool inPillar;
    [SerializeField] Animator anim;
    // Update is called once per frame
    void Update()
    {
        moving = moviment.instance.dirMove.magnitude;
        isRun = moviment.instance.runing;
        isground = moviment.instance.isGround;
        inPillar = MovimentInPillar.Instance.inPillar;

        anim.SetBool("Runing", isRun);
        anim.SetBool("climb", inPillar);
        anim.SetBool("isGround", isground);
        anim.SetFloat("isMove", moving);
    }
}
