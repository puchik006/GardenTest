using System.Collections.Generic;
using UnityEngine;

public class scr_UI_Inventory: MonoBehaviour
{
    [SerializeField] private List<scr_UI_InventoryItem> _listOfItems;
    [SerializeField] private GameObject _inventoryPanel;
    private scr_Inventory _inventory;

    public void V_Initialise()
    {
        _inventory = new scr_Inventory();
        scr_EventBus.Instance.InventoryOpened += V_OnInventoryOpened;
        scr_EventBus.Instance.PlayerTookItem += V_OnPlayerTookItem;
        scr_EventBus.Instance.ButtonDeletePressed += V_OnButtonDeletePressed;
    }

    private void V_CheckInventory()
    {
        if (!_inventoryPanel.activeSelf) return; 

        _listOfItems.ForEach(item => item.V_FillEmptyItem());

        for (int i = 0; i < _inventory.D_Inventory.ListOfItems.Count; i++)
        {
            _listOfItems[i].V_InitialiseItem(_inventory.D_Inventory.ListOfItems[i]);
        }
    }

    private void V_OnInventoryOpened()
    {
        V_CheckInventory();
    }

    private void V_OnPlayerTookItem(D_InventoryItem item)
    {
        V_CheckInventory();
    }

    private void V_OnButtonDeletePressed(D_InventoryItem item)
    {
        V_CheckInventory();
    }
 
    void OnDestroy()
    {
        scr_EventBus.Instance.InventoryOpened -= V_OnInventoryOpened;
        scr_EventBus.Instance.PlayerTookItem -= V_OnPlayerTookItem;
        scr_EventBus.Instance.ButtonDeletePressed -= V_OnButtonDeletePressed;
    }
}




