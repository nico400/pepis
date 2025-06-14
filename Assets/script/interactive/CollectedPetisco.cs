using UnityEngine;

public class CollectedPetisco : MonoBehaviour
{
    
    void Start()
    {
        collectedObj._colecterObj += addPointCollectedPetisco;
    }

    void addPointCollectedPetisco()
    {
        moviment.points++;
    }

}
