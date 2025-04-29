using UnityEngine;

public class ActiveLever : MonoBehaviour
{
    [SerializeField] TowerComp tw;
    public int idLever;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (tw.idTower == idLever)
            {
                print("a");
            }
        }
    }
}
