using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevelManager : MonoBehaviour
{
    [SerializeField] string nameSceneLevel;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (moviment.instance.interactive)
            {
                SceneManager.LoadScene(nameSceneLevel);
            }
        }
    }
}
