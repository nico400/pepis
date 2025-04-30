using UnityEngine;

public class TowerComp : MonoBehaviour
{
    [SerializeField] int idTower;
    [SerializeField] bool activeTower;

    private void Start()
    {
        ActiveLever.callback += Active;
    }
    void Active(int id)
    {
        if (id == idTower)
        {
            activeTower = true;
        }
    }
}
