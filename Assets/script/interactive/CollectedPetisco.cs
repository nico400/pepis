using UnityEngine;

public class CollectedPetisco : MonoBehaviour
{
    private Inventario inventario;

    void Start()
    {
        inventario = FindAnyObjectByType<Inventario>();
        collectedObj._colecterObj += addPointCollectedPetisco;
    }

    void addPointCollectedPetisco()
    {
        inventario.AdicionarPonto();
    }
}
