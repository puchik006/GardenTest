using UnityEngine;

public class scr_FilesManager_ItemsLoader: MonoBehaviour
{
    [SerializeField] private D_Items _allItems;

    private scr_JSONHandler _jsonHandler;

    private void Awake()
    {
        _jsonHandler = new scr_JSONHandler();

        _jsonHandler.V_ReadDataFromFile<D_Items>("Items.json");
    }

}
