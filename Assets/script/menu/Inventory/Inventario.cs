using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<ItemCreator> itens = new List<ItemCreator>(); 

    public void AdicionarItem(ItemCreator item) {

        if (!itens.Contains(item)) {

            itens.Add(item);
            
        }
    }

    public void RemoverItem(ItemCreator item) {

        if (itens.Contains(item)) {

            itens.Remove(item);

        }
    }
}
