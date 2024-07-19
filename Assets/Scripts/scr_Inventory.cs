using System;
using UnityEngine;
using static scr_General;

public class scr_Inventory
{
    private D_Inventory _d_Inventory;
    public D_Inventory D_Inventory { get => _d_Inventory; }
    private scr_JSONHandler _jsonHandler;
    private const int INVENTORY_MAX = 7;

    public scr_Inventory()
    {
        _jsonHandler = new scr_JSONHandler();
        scr_EventBus.Instance.PlayerTryingToTakeItem += V_OnPlayerTakeItem;
        V_CheckInventory();
    }

    public void V_CheckInventory()
    {
        _d_Inventory = _jsonHandler.V_ReadDataFromJSONFile<D_Inventory>("Inventory.json");
    }

    private void V_OnPlayerTakeItem(D_InventoryItem item)
    {
        // Check if item is new in inventory
        D_InventoryItem existingItem = _d_Inventory.ListOfItems.Find(i => i.ItemName == item.ItemName);

        if (existingItem.ItemName != null)
        {
            // Update existing item quantity
            existingItem.Quantity += item.Quantity;
            int index = _d_Inventory.ListOfItems.FindIndex(i => i.ItemName == item.ItemName);
            _d_Inventory.ListOfItems[index] = existingItem; // Update the item in the list
        }
        else
        {
            if (_d_Inventory.ListOfItems.Count < INVENTORY_MAX)
            {
                _d_Inventory.ListOfItems.Add(item);
            }
            else
            {
                Console.WriteLine("Inventory is full!");
            }
        }

        //Save inventory
        _jsonHandler.V_SaveDataToJSONFile(m_General.GET_InventoryName, _d_Inventory);
        V_CheckInventory();
        scr_EventBus.Instance.PlayerTookItem?.Invoke(item);
    }
}




