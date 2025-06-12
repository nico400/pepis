using UnityEngine;

public class ObjInventory : collectedObj
{
    [SerializeField] Inventario inventario;

    private void Start()
    {
        if(inventario == null)
            inventario = FindObjectOfType<Inventario>();

        collectedObj._colecterObj += ColetarItensProximos;

    }

    public void ColetarItensProximos()
    {
        /*
        Collider[] itensNoRaio = Physics.OverlapSphere(transform.position, raioDeColeta);

        foreach (Collider col in itensNoRaio)
        {

            collectedObj collectedObj = col.GetComponent<collectedObj>();
            if (collectedObj != null)
            {

                inventario.AdicionarItem(collectedObj.item); // Bota no inventario
                Destroy(collectedObj.gameObject); // Disbota no mundo
            }
        }*/

        inventario.AdicionarItem(this.item);

    }
}
