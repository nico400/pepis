using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quitGame : MonoBehaviour
{
    public void quitTheGame()
    {
        Application.Quit();
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
