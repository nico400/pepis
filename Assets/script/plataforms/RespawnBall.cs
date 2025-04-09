using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    [SerializeField] GameObject newBall;
    [SerializeField] GameObject BallIsLive;

    void Update()
    {
        if (BallIsLive == null)
        {
            var newBallInst = Instantiate(newBall);
            BallIsLive = newBallInst;

            newBallInst.transform.position = transform.position + Vector3.up * 2.5f;
        }
    }
}
