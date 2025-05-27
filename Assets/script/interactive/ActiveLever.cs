using UnityEngine;

public class ActiveLever : MonoBehaviour
{
    [SerializeField] int id_linkTower;
    [SerializeField] bool active;

    public delegate void LeverCallback(int id);
    public static event LeverCallback callback;

    private void Start()
    {
        active = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && !active)
        {
            if (moviment.instance.interactive)
            {
                callback?.Invoke(id_linkTower);
                active = true;
            }
        }
    }
}
