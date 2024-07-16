using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI_InventoryItem: MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _quantity;

    public void V_InitialiseItem(Sprite icon, int quantity, D_InventoryItem item)
    {
        _icon.sprite = icon;
        _quantity.text = quantity.ToString();
        _button.onClick.AddListener(() => scr_EventBus.Instance.ItemButtonPressed?.Invoke(item));
    }

    public void V_ChangeItemQuantity()
    {

    }
}
