using UnityEngine;

public class StartRotateScrew : MonoBehaviour
{
    public static StartRotateScrew instance;
    private void Start()
    {
        instance = this;
    }

    public delegate void EventRotateScrew(int id);
    public static event EventRotateScrew OnRotateScrew;

    [SerializeField] int Id_linkScrew;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            OnRotateScrew?.Invoke(Id_linkScrew);
        }
    }
    public int getLinkId()
    {
        return Id_linkScrew;
    }

}
