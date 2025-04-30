using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class pular : MonoBehaviour
{
    public float tempo;
    [SerializeField] private string proximaCena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if(tempo > 2.79f){


            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(proximaCena);
                print("proximaSena");
            }
        }
    }
}
