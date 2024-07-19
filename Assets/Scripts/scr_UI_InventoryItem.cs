using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI_InventoryItem: MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _quantity;

    private scr_Media_ImageLoader _imageLoader;

    void Awake()
    {
        _imageLoader = new scr_Media_ImageLoader();
        V_FillEmptyItem();
    }

    public void V_InitialiseItem(D_InventoryItem item)
    {
        string imagePath = Path.Combine(Application.persistentDataPath, "Items", item.ItemName, item.ItemName + ".png");

        _icon.color = Color.white;
        _icon.sprite = _imageLoader.GetSpriteFromPath(imagePath);
        _quantity.text = item.Quantity.ToString();
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => scr_EventBus.Instance.ItemButtonPressed?.Invoke(item));
    }

    public void V_ChangeItemQuantity()
    {

    }

    private void V_FillEmptyItem()
    {
        _icon.color = Color.black;
        _quantity.text = "0";
    }
}
