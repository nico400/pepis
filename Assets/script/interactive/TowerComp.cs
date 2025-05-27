using UnityEngine;

public class TowerComp : MonoBehaviour
{
    [SerializeField] int idTower;
    public bool activeTower {  get; private set; }

    public delegate void OnCutSceneActive();
    public static event OnCutSceneActive _OnCutSceneActive;

    private void Start()
    {
        ActiveLever.callback += Active;
    }
    void Active(int id)
    {
        if (id == idTower)
        {
            activeTower = true;
            _OnCutSceneActive?.Invoke();
        }
    }
}
