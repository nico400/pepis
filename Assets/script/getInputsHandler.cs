using UnityEngine;

public class getInputsHandler : MonoBehaviour
{
    InputsAction inputAction;
    public Vector2 dirXY { get; private set; }
    public bool jump { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputAction = new InputsAction();
    }
    void OnEnable()
    {
        inputAction.Enable();
    }
    void OnDisable()
    {
        inputAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        dirXY = inputAction.Player.move.ReadValue<Vector2>();
        jump = inputAction.Player.jump.triggered;
    }
}
