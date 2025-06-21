using UnityEngine;

public class rotateOBJ : MonoBehaviour
{
    [SerializeField] Transform posPlayer;
    float dirToRotate;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (moviment.instance.holdObj && moviment.instance.canHold)
            {
                other.transform.position = posPlayer.position;
                other.transform.rotation = posPlayer.rotation;
                dirToRotate = moviment.instance.dirMove.x;

                transform.Rotate(new Vector3(0, dirToRotate * 15 * Time.deltaTime,0), Space.Self);

            }
        }
    }
}
