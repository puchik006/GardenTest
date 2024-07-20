using UnityEngine;
using UnityEngine.UI;

public class scr_UI_Handler: MonoBehaviour
{
    [SerializeField] private Button _btnInventory;
    [SerializeField] private Button _btnFire;
    [SerializeField] private GameObject _inventoryPanel;

    void Awake()
    {
        _inventoryPanel.SetActive(false);
        _btnInventory.onClick.AddListener(V_ToggleInventoryPanel);
        _btnFire.onClick.AddListener(V_Fire);
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
}
