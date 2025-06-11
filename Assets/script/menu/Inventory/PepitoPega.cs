using UnityEngine;

public class PepitoPega : MonoBehaviour {

    public float raioDeColeta = 3f;
    public LayerMask camadaItem; 
    private Inventario inventario;

    private void Start() {

        inventario = FindObjectOfType<Inventario>(); 
    }
    void Update() {

        if (Input.GetKeyDown(KeyCode.L)) 
        {
            ColetarItensProximos();
        }
    }

    public void ColetarItensProximos() {
        
        Collider[] itensNoRaio = Physics.OverlapSphere(transform.position, raioDeColeta, camadaItem);

        foreach (Collider col in itensNoRaio) {

            collectedObj collectedObj = col.GetComponent<collectedObj>();
            if (collectedObj != null) {

                inventario.AdicionarItem(collectedObj.item); // Bota no inventario
                Destroy(collectedObj.gameObject); // Disbota no mundo
            }
        }
    }
}
