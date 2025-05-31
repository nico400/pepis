using UnityEngine;

public class PepitoPega : MonoBehaviour {

    public float raioDeColeta = 3f;
    public LayerMask camadaItem; 
    private Inventario inventario;

    private void Start() {

        inventario = FindFirstObjectOfType<Inventario>(); 
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            ColetarItensProximos();
        }
    }

    public void ColetarItensProximos() {
        
        Collider[] itensNoRaio = Physics.OverlapSphere(transform.position, raioDeColeta, camadaItem);

        foreach (Collider col in itensNoRaio) {

            ColliderD ColliderD = col.GetComponent<ColliderD>();
            if (ColliderD != null) {

                inventario.AdicionarItem(ColliderD.item); // Bota no inventario
                Destroy(ColliderD.gameObject); // Disbota no mundo
            }
        }
    }
}
