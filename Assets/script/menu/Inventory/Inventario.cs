using UnityEngine;
using System.Collections.Generic;

public class Inventario : MonoBehaviour
{
    public List<ItemCreator> itens = new List<ItemCreator>();
    public SaveSystem saveSystem;
    private int pontos = 0;
    public Transform jogador;
    public List<string> biscoitosColetados = new List<string>();

    private void Start()
    {
        saveSystem = FindAnyObjectByType<SaveSystem>();
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        CarregarInventario();
    }
       
    public void AdicionarItem(ItemCreator item)
    {
        if (!itens.Contains(item))
        {
            itens.Add(item);
            FindAnyObjectByType<InventarioUI>().AtualizarInventarioUI();
            saveSystem.SalvarDados(this, pontos, jogador.position, biscoitosColetados);
        }
    }

    public void RemoverItem(ItemCreator item)
    {
        if (itens.Contains(item))
        {
            itens.Remove(item);
            FindAnyObjectByType<InventarioUI>().AtualizarInventarioUI();
            saveSystem.SalvarDados(this, pontos, jogador.position, biscoitosColetados);
        }
    }

    public void AdicionarBiscoito(GameObject biscoito)
    {
        string biscoitoID = biscoito.name;

        if (!biscoitosColetados.Contains(biscoitoID))
        {
            biscoitosColetados.Add(biscoitoID);
            saveSystem.SalvarDados(this, pontos, jogador.position, biscoitosColetados);
            Destroy(biscoito);
        }
    }

    public void CarregarInventario()
    {
        saveSystem.CarregarDados(this, ref pontos, jogador, ref biscoitosColetados);

        GameObject[] biscoitosNaCena = GameObject.FindGameObjectsWithTag("Biscoito");
        foreach (GameObject biscoito in biscoitosNaCena)
        {
            if (biscoitosColetados.Contains(biscoito.name))
            {
                Destroy(biscoito);
            }
        }
    }

    public void AdicionarPonto()
    {
        pontos++;
        saveSystem.SalvarDados(this, pontos, jogador.position, biscoitosColetados);
    }

    public int GetPontos()
    {
        return pontos;
    }
}
