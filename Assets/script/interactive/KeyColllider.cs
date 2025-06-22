using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyColllider : MonoBehaviour
{

    public bool isOneKey;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (isOneKey)
            {
                OpenFinalDoor.keyOne = true;
            }else
            {
                OpenFinalDoor.keyTwo = true;
            }
            SceneManager.LoadScene("hub");
        }       
    }
}
