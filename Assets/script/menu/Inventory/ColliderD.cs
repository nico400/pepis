using UnityEngine;

public class ColliderD : MonoBehaviour {
    
    public ItemCreator item; //Essekralho ai tá "juntando" o objeto com scriptable object

    private void Start() {

        if (GetComponent<Collider>() == null) {

            gameObject.AddComponent<SphereCollider>().isTrigger = true; 

        }
    }
}
