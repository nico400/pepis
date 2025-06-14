using UnityEngine;

public class PepitoPega : MonoBehaviour {
    private Inventario inventario;

    private void Start() {
        inventario = FindObjectOfType<Inventario>(); 
    }

    private void OnTriggerEnter(Collider other) {
        collectedObj collectedObj = other.GetComponent<collectedObj>();
        
        if (collectedObj != null) {
            inventario.AdicionarItem(collectedObj.item); // Adiciona ao inventário
            Destroy(collectedObj.gameObject); // Remove o item do mundo
        }
    }
}
