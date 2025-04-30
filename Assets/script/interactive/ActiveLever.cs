using UnityEngine;

public class ActiveLever : MonoBehaviour
{
    [SerializeField] int id_linkTower;

    public delegate void LeverCallback(int id);
    public static event LeverCallback callback;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if(moviment.instance.interactive)
                callback?.Invoke(id_linkTower);
        }
    }
}
