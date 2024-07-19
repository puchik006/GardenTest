using System.Collections.Generic;
using UnityEngine;

public class scr_UI_Inventory: MonoBehaviour
{
    [SerializeField] private List<scr_UI_InventoryItem> _listOfItems;
    private scr_Inventory _inventory;

    void Awake()
    {
        _inventory = new scr_Inventory();
        scr_EventBus.Instance.PlayerTookItem += OnPlayerTookItem;
        scr_EventBus.Instance.ButtonDeletePressed += OnButtonDeletePressed;
    }

    void Start()
    {
        V_CheckInventory();
    }

    private void V_CheckInventory()
    {
        _listOfItems.ForEach(item => item.V_FillEmptyItem());

        for (int i = 0; i < _inventory.D_Inventory.ListOfItems.Count; i++)
        {
            _listOfItems[i].V_InitialiseItem(_inventory.D_Inventory.ListOfItems[i]);
        }
    }

    private void OnPlayerTookItem(D_InventoryItem item)
    {
        V_CheckInventory();
    }


    private void OnButtonDeletePressed(D_InventoryItem item)
    {
        V_CheckInventory();
    }
}




