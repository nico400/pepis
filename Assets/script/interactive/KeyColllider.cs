using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyColllider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("hub");
    }
}
