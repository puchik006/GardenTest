using System;
using System.Collections.Generic;
using UnityEngine;
using static scr_General;

public class scr_UI_Inventory: MonoBehaviour
{
    [SerializeField] private List<scr_UI_InventoryItem> _listOfItems;
    private scr_Inventory _inventory;

    void Awake()
    {
        _inventory = new scr_Inventory();
        scr_EventBus.Instance.PlayerTookItem += OnPlayerTookItem;
    }

    void Start()
    {
        V_CheckInventory();
    }

    private void V_CheckInventory()
    {
        for (int i = 0; i < _inventory.D_Inventory.ListOfItems.Count; i++)
        {
            _listOfItems[i].V_InitialiseItem(_inventory.D_Inventory.ListOfItems[i]);
        }
    }

    private void OnPlayerTookItem(D_InventoryItem item)
    {
        V_CheckInventory();
    }

    //private void V_OnPlayerTakeItem(D_InventoryItem item)
    //{
    //    _d_Inventory.Inventory.Add(item);
    //    V_CheckInventory();
    //}

    //public void V_SaveInventory()
    //{
    //    _jsonHandler.V_SaveDataToJSONFile<D_Inventory>(m_General.GET_InventoryName, _d_Inventory);
    //}

}




