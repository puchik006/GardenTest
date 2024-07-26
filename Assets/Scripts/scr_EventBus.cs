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
    public Action<D_InventoryItem> PlayerTryedToTakeItem;
    public Action<D_InventoryItem> PlayerTookItem;
    public Action<D_InventoryItem> ButtonDeletePressed;
    public Action InventoryOpened;

    //Weapon
    public Action FireButtonPressed;
    public Action TryedToConsumeAmmo;
    public Action AmmoConsumed;
    public Action<int> AmmoQuantityChecked;

    //Enemy
    public Action EnemyDestroyed;

    //GamaPhase
    //public Action<E_GamePhase> GamePhaseUpdate;


}