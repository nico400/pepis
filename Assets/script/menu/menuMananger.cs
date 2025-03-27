using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuMananger : MonoBehaviour
{
    [SerializeField] private string proximaCena;
    [SerializeField] GameObject config;
    [SerializeField] GameObject creditos;
    void Start()
    {
        
        if (config.activeSelf)
        {
            config.SetActive(false);
        }

        if (creditos.activeSelf)
        {
            creditos.SetActive(false);
        }
    }

   public void Jogar()
    {
        SceneManager.LoadScene(proximaCena);
    }

    public void Config()
    {
        config.SetActive(true);           
    }

    public void Creditos()
    {
        creditos.SetActive(true);
    }
    public void Continuar()
    {

    }
    public void SairOpcao()
    {

        config.SetActive(false);

        creditos.SetActive(false);
    }
}
