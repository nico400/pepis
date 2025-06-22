using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenFinalDoor : MonoBehaviour
{

    public static bool keyOne;
    public static bool keyTwo;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && keyTwo && keyOne)
        {
            SceneManager.LoadScene("Final");
        }
    }
}
