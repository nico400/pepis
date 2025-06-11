using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public Transform container;
    public GameObject itemPrefab;
    public GameObject inventariopassivo;    
    public GameObject painelDetalhes; 
    public Image imagemDetalhes; 
    public TMP_Text nomeDetalhes; 
    public TMP_Text descricaoDetalhes; 
    private Inventario inventario;

    private void Start()
    {
        AtualizarInventarioUI();
        painelDetalhes.SetActive(false);
    }

    public void AtualizarInventarioUI()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in inventario.itens)
        {
            GameObject itemUI = Instantiate(itemPrefab, container);
            itemUI.GetComponent<Image>().sprite = item.Icone;
            itemUI.GetComponent<Button>().onClick.AddListener(() => MostrarDetalhes(item));
        }
    }

    public void MostrarDetalhes(ItemCreator item)
    {
        painelDetalhes.SetActive(true);
        inventariopassivo.SetActive(true);
        imagemDetalhes.sprite = item.Icone;
        nomeDetalhes.text = item.Name;
        descricaoDetalhes.text = item.Description;
    }
}
