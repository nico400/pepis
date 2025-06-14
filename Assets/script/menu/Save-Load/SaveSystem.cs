using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string caminhoArquivo => Application.persistentDataPath + "/save.json";

    public void SalvarDados(Inventario inventario, int pontos, Vector3 posicaoJogador, List<string> biscoitosColetados)
    {
        SaveData saveData = new SaveData(inventario.itens, pontos, posicaoJogador, biscoitosColetados);
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(caminhoArquivo, json);
        Debug.Log("Jogo salvo!");
    }

    public void CarregarDados(Inventario inventario, ref int pontos, Transform jogador, ref List<string> biscoitosColetados)
    {
        if (File.Exists(caminhoArquivo))
        {
            string json = File.ReadAllText(caminhoArquivo);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            inventario.itens = new List<ItemCreator>(saveData.itens);
            pontos = saveData.pontos;
            jogador.position = saveData.posicaoJogador;
            biscoitosColetados = saveData.biscoitosColetados;
            FindAnyObjectByType<InventarioUI>().AtualizarInventarioUI();

            Debug.Log("Jogo carregado!");
        }
        else
        {
            Debug.LogWarning("Nenhum arquivo de save encontrado!");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public List<ItemCreator> itens;
    public int pontos;
    public Vector3 posicaoJogador;
    public List<string> biscoitosColetados;

    public SaveData(List<ItemCreator> itensSalvos, int pontosSalvos, Vector3 posicaoJogadorSalva, List<string> biscoitosSalvos)
    {
        this.itens = itensSalvos;
        this.pontos = pontosSalvos;
        this.posicaoJogador = posicaoJogadorSalva;
        this.biscoitosColetados = biscoitosSalvos;
    }
}
