using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI_InventoryItem: MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _btnDelete;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _quantity;
    [SerializeField] private GameObject _backGroundQuantity;
    private D_InventoryItem _item;
    private scr_Media_ImageLoader _imageLoader;
    private const int MIN_QUANTITY_TO_SHOW = 2;

    void Awake()
    {
        _imageLoader = new scr_Media_ImageLoader();
    }

    public void V_InitialiseItem(D_InventoryItem item)
    {
        _item = item;
        string imagePath = Path.Combine(Application.persistentDataPath, "Items", item.ItemName, item.ItemName + ".png"); //CHANGE!

        _icon.color = Color.white;
        _icon.sprite = _imageLoader.GetSpriteFromPath(imagePath);
        _backGroundQuantity.SetActive(item.Quantity >= MIN_QUANTITY_TO_SHOW);
        _quantity.text = item.Quantity.ToString();
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(V_MainButtonPressed);
    }

    public void V_FillEmptyItem()
    {
        _icon.sprite = null;
        _icon.color = Color.black;
        _backGroundQuantity.SetActive(false);
        _button.onClick.RemoveAllListeners();
    }

    private void V_MainButtonPressed()
    {
        _btnDelete.gameObject.SetActive(true);
        _btnDelete.onClick.RemoveAllListeners();
        _btnDelete.onClick.AddListener(V_ButtonDeletePressed);
        scr_EventBus.Instance.ItemButtonPressed?.Invoke(_item);
    }

    private void V_ButtonDeletePressed()
    {
        _btnDelete.gameObject.SetActive(false);
        scr_EventBus.Instance.ButtonDeletePressed?.Invoke(_item);
    }
}
