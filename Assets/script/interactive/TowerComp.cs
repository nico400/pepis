using UnityEngine;

public class TowerComp : MonoBehaviour
{
    [SerializeField] int idTower;
    public bool activeTower {  get; private set; }

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
