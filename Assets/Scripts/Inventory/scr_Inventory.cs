﻿using UnityEngine;
using System.Collections.Generic;

public class scr_Inventory
{
    private D_Inventory _d_Inventory;
    public D_Inventory D_Inventory { get => _d_Inventory; }
    private scr_FileManager_JSONHandler _jsonHandler;
    private const int INVENTORY_MAX = 7;
    private string _inventoryDataFileName = "Inventory.json";
    private string _itemCatalogFileName = "Items.json";

    public scr_Inventory()
    {
        _jsonHandler = new scr_FileManager_JSONHandler();
        scr_EventBus.Instance.PlayerTryedToTakeItem += V_OnPlayerTakeItem;
        scr_EventBus.Instance.ButtonDeletePressed += V_OnButtonDeletePressed;
        scr_EventBus.Instance.TryedToConsumeAmmo += V_OnTryedToConsumeAmmo;
        V_CheckInventory();
    }

    public void V_CheckInventory()
    {

        if (_jsonHandler.Is_JSON_Exist(_inventoryDataFileName))
        {
            _d_Inventory = _jsonHandler.V_ReadDataFromJSONFile<D_Inventory>(_inventoryDataFileName);
        }
        else
        {
            var initiateInventory = new D_Inventory()
            {
                ListOfItems = new List<D_InventoryItem>()
                {
                    new D_InventoryItem()
                    {
                        ItemName = "5.45x39",
                        Quantity = 30
                    }
                }
            };

            _jsonHandler.V_SaveDataToJSONFile(_inventoryDataFileName, initiateInventory);
            _d_Inventory = _jsonHandler.V_ReadDataFromJSONFile<D_Inventory>(_inventoryDataFileName);
        }

        
        V_CheckAmmoQuantity();
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
                Debug.Log("Inventory is full!");
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

    //Trying to consume just an ammo in inventory, without cheking certain type
    private void V_OnTryedToConsumeAmmo()
    {
        var items = _jsonHandler.V_ReadDataFromJSONFile<D_Items>(_itemCatalogFileName);

        var ammoTypeListOfItems = items.Items.FindAll(i => i.Type == E_ItemType.Ammo);

        foreach (var ammoType in ammoTypeListOfItems)
        {
            D_InventoryItem existingAmmo = _d_Inventory.ListOfItems.Find(i => i.ItemName == ammoType.Name);

            if (existingAmmo.ItemName != null)
            {
                D_InventoryItem itemToConsume = new D_InventoryItem { ItemName = existingAmmo.ItemName, Quantity = 1 }; 

                if (existingAmmo.Quantity >= itemToConsume.Quantity)
                {
                    existingAmmo.Quantity -= itemToConsume.Quantity;
                    int index = _d_Inventory.ListOfItems.FindIndex(i => i.ItemName == existingAmmo.ItemName);
                    _d_Inventory.ListOfItems[index] = existingAmmo;

                    if (existingAmmo.Quantity == 0)
                    {
                        _d_Inventory.ListOfItems.Remove(existingAmmo);
                    }

                    V_UpdateInventory(existingAmmo);

                    scr_EventBus.Instance.AmmoConsumed?.Invoke();
                    return; 
                }
                else
                {
                    Debug.Log("Not enough ammo!");
                    return; 
                }
            }
        }

        Debug.Log("No matching ammo found in inventory!");
    }

    //Check ammo quantity
    private void V_CheckAmmoQuantity()
    {
        var items = _jsonHandler.V_ReadDataFromJSONFile<D_Items>(_itemCatalogFileName);

        var ammoTypeListOfItems = items.Items.FindAll(i => i.Type == E_ItemType.Ammo);

        if (ammoTypeListOfItems.Count == 0)
        {
            scr_EventBus.Instance.AmmoQuantityChecked?.Invoke(0);
        }

        foreach (var ammoType in ammoTypeListOfItems)
        {
            D_InventoryItem existingAmmo = _d_Inventory.ListOfItems.Find(i => i.ItemName == ammoType.Name);

            if (existingAmmo.ItemName != null)
            {
                scr_EventBus.Instance.AmmoQuantityChecked?.Invoke(existingAmmo.Quantity);
            }
            else
            {
                scr_EventBus.Instance.AmmoQuantityChecked?.Invoke(0);
            }
        }
    }

    private void V_UpdateInventory(D_InventoryItem item)
    {
        _jsonHandler.V_SaveDataToJSONFile(_inventoryDataFileName, _d_Inventory);
        V_CheckInventory();
        scr_EventBus.Instance.PlayerTookItem?.Invoke(item);
    }

    ~scr_Inventory()
    {
        scr_EventBus.Instance.PlayerTryedToTakeItem -= V_OnPlayerTakeItem;
        scr_EventBus.Instance.ButtonDeletePressed -= V_OnButtonDeletePressed;
        scr_EventBus.Instance.TryedToConsumeAmmo -= V_OnTryedToConsumeAmmo;
    }
}




