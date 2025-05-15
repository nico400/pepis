using UnityEngine;
using UnityEngine.InputSystem;

public class getInputsHandler : MonoBehaviour
{
    InputsAction inputAction;
    public Vector2 dirXY { get; private set; }
    public Vector2 mouseXY { get; private set; }
    public bool jump { get; private set; }
    public bool runShift { get; private set; }
    public bool runGamepad { get; private set; }
    public bool holdOrNot { get; private set; }
    public bool interactived { get; private set; }
    public bool exitUiPainel { get; private set; }
    public bool openUiPinal { get; private set; }

    InputAction HoldObj;
    InputAction inter;
    InputAction ruing;
    InputAction ruingGamepad;
    InputAction exitUi;
    InputAction openInventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputAction = new InputsAction();     
    }
    void OnEnable()
    {
        inputAction.Enable();
        HoldObj = inputAction.Player.launchBall;
        inter = inputAction.Player.Interact;
        ruing = inputAction.Player.runing;
        ruingGamepad = inputAction.Player.runGamepad;
        exitUi = inputAction.ui.ExitPainel;
        openInventory = inputAction.ui.OpenPainel;

        HoldObj.started += _Startlaunc;
        HoldObj.canceled += _Stoplaunc;
        inter.started += Startinteractive;
        inter.canceled += Stoptinteractive;     
    }
    void OnDisable()
    {
        inputAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        dirXY = inputAction.Player.move.ReadValue<Vector2>();
        mouseXY = inputAction.Player.mouseAim.ReadValue<Vector2>();
        jump = inputAction.Player.jump.triggered;
        exitUiPainel = exitUi.triggered;
        openUiPinal = openInventory.triggered;

        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            ruing.started += StartRun;
            ruing.canceled += StopRun;
        }
        else
        {
            runGamepad = ruingGamepad.triggered;
            runShift = false;

            ruing.started -= StartRun;
            ruing.canceled -= StopRun;
        }     
    }
    void Startinteractive(InputAction.CallbackContext contex)
    {
        interactived = true;
    }
    void Stoptinteractive(InputAction.CallbackContext contex)
    {
        interactived = false;
    }

    void _Startlaunc(InputAction.CallbackContext contex)
    {
        holdOrNot = true;
    }
    void _Stoplaunc(InputAction.CallbackContext contex)
    {
        holdOrNot = false;
    }
    void StartRun(InputAction.CallbackContext contex)
    {
        runShift = true;
    }
    void StopRun(InputAction.CallbackContext contex)
    {
        runShift = false;
    }
}
