using System.IO;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class scr_UI_DropableItem : MonoBehaviour
{
    [SerializeField] private string _itemName; // key to D_Item
    private SpriteRenderer _spriteRenderer;
    private scr_Media_ImageLoader _imageLoader;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _imageLoader = new scr_Media_ImageLoader();
        V_InitialiseItem(_itemName);
    }

    public void V_InitialiseItem(string itemName)
    {
        if (string.IsNullOrEmpty(itemName)) return;

        string imagePath = Path.Combine(Application.persistentDataPath, "Items", itemName, itemName + ".png"); //CHANGE IT!!!

        Sprite sprite = _imageLoader.GetSpriteFromPath(imagePath);

        if (sprite != null)
        {
            _spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Failed to load sprite from path: " + imagePath);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scr_EventBus.Instance.PlayerTryingToTakeItem(new D_InventoryItem { ItemName = _itemName, Quantity = 1});
    }
}
