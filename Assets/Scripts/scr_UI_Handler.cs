using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI_Handler: MonoBehaviour
{
    [SerializeField] private Button _btnInventory;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Button _btnFire;
    [SerializeField] private TMP_Text _txtAmmoCount;

    void Awake()
    {
        _inventoryPanel.SetActive(false);
        _btnInventory.onClick.AddListener(V_ToggleInventoryPanel);
        _btnFire.onClick.AddListener(V_Fire);
        scr_EventBus.Instance.AmmoQuantityChecked += V_OnAmmoQuantityChecked;
    }

    private void V_ToggleInventoryPanel()
    {
        bool isActive = !_inventoryPanel.activeSelf;
        _inventoryPanel.SetActive(isActive);

        if (isActive)
        {
            scr_EventBus.Instance.InventoryOpened?.Invoke();
        }
    }

    private void V_Fire()
    {
        scr_EventBus.Instance.FireButtonPressed?.Invoke();
    }

    private void V_OnAmmoQuantityChecked(int ammoQuantity)
    {
        _txtAmmoCount.text = ammoQuantity.ToString();
    }
}
