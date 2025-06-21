using UnityEngine;
using UnityEngine.SceneManagement;

public class restarLv2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Scene acScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(acScene.name);
    }
}
