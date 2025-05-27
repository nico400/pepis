using UnityEngine;

public class activeCutscene : MonoBehaviour
{
    [SerializeField] int countEvents;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TowerComp._OnCutSceneActive += events;
        countEvents = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void events()
    {
        
    }

}
