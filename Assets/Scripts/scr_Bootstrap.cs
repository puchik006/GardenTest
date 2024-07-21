using UnityEngine;

public class scr_Bootstrap: MonoBehaviour
{
    [SerializeField] private scr_UI_Handler _ui_Handler;
    [SerializeField] private scr_UI_Inventory _ui_inventory;

    void Awake()
    {
        _ui_Handler.V_Initialise();
        _ui_inventory.V_Initialise();
    }
}




