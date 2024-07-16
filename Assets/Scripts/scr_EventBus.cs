using System;

public class scr_EventBus
{
    private scr_EventBus() { }

    private static scr_EventBus _instance;

    public static scr_EventBus Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new scr_EventBus();
            }

            return _instance;
        }
    }

    //Inventory
    public Action<D_InventoryItem> ItemButtonPressed;


    //
    //public Action<E_GamePhase> GamePhaseUpdate;


}