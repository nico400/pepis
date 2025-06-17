using UnityEngine;

public class OptionMenuManager : MonoBehaviour
{
    [SerializeField] GameObject optionInventoryPainel;
    [SerializeField] GameObject inventoryPainel;
    [SerializeField] GameObject OptionPainel;
    [SerializeField] getInputsHandler getInputHandler;

    [SerializeField] bool optionOpened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        getInputHandler = GetComponent<getInputsHandler>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (optionInventoryPainel != null)
            optionInventoryPainel.SetActive(false);
        if (inventoryPainel != null && OptionPainel != null)
        {
            inventoryPainel.SetActive(true);
            OptionPainel.SetActive(false);
        }
        optionOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (optionInventoryPainel == null)
            return;
            
        if (getInputHandler.openUiPinal && !optionOpened)
        {
            optionOpened = true;
            moviment.instance.canMove = false;
            optionInventoryPainel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (getInputHandler.exitUiPainel && optionOpened)
        {
            optionOpened = false;
            moviment.instance.canMove = true;
            optionInventoryPainel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void OpenInventory()
    {
        inventoryPainel.SetActive(true);
        OptionPainel.SetActive(false);
    }
    public void OpenOption()
    {
        OptionPainel.SetActive(true);
        inventoryPainel.SetActive(false);
    }

}
