using UnityEngine;

public class SalvadorDali : MonoBehaviour
{
    private Inventario inventario;

    private void Start()
    {
        inventario = FindAnyObjectByType<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventario.saveSystem.SalvarDados(inventario, inventario.GetPontos(), inventario.jogador.position, inventario.biscoitosColetados);
            Debug.Log("Jogo salvo ao interagir com o Hidrante!");
        }
    }
}
