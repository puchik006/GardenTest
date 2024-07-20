﻿using System;
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
        scr_EventBus.Instance.ButtonDeletePressed += V_OnButtonDeletePressed;
        V_CheckInventory();
    }

    public void V_CheckInventory()
    {
        _d_Inventory = _jsonHandler.V_ReadDataFromJSONFile<D_Inventory>("Inventory.json"); // CHANGE IT!
    }

    private void V_OnPlayerTakeItem(D_InventoryItem item)
    {
        D_InventoryItem existingItem = _d_Inventory.ListOfItems.Find(i => i.ItemName == item.ItemName);

        if (existingItem.ItemName != null)
        {
            existingItem.Quantity += item.Quantity;
            int index = _d_Inventory.ListOfItems.FindIndex(i => i.ItemName == item.ItemName);
            _d_Inventory.ListOfItems[index] = existingItem;
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

        V_UpdateInventory(item);
    }

    private void V_OnButtonDeletePressed(D_InventoryItem item)
    {
        D_InventoryItem existingItem = _d_Inventory.ListOfItems.Find(i => i.ItemName == item.ItemName);

        if (existingItem.ItemName != null)
        {
             _d_Inventory.ListOfItems.Remove(existingItem);

            V_UpdateInventory(item);
        }
    }

    private void V_UpdateInventory(D_InventoryItem item)
    {
        _jsonHandler.V_SaveDataToJSONFile(m_General.GET_InventoryName, _d_Inventory);
        V_CheckInventory();
        scr_EventBus.Instance.PlayerTookItem?.Invoke(item);
    }

    ~scr_Inventory()
    {
        scr_EventBus.Instance.PlayerTryingToTakeItem -= V_OnPlayerTakeItem;
        scr_EventBus.Instance.ButtonDeletePressed -= V_OnButtonDeletePressed;
    }
}




