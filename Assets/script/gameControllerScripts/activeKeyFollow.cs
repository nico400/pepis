using UnityEngine;

public class activeKeyFollow : MonoBehaviour
{
    [SerializeField] TowerComp towerOne;
    [SerializeField] TowerComp towerTwo;

    [SerializeField] GameObject keyActive;
    void Start()
    {
        keyActive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (towerOne.activeTower && towerTwo.activeTower)
        {
            keyActive.SetActive(true);
        }
    }
}
