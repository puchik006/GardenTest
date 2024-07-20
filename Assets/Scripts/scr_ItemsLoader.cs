using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class scr_ItemsLoader : MonoBehaviour
{
    [SerializeField] private D_Items _d_Items;
    [SerializeField] private string itemsFolderPath = "Items";
    private scr_JSONHandler _jsonHandler;

    private void Awake()
    {
        _jsonHandler = new scr_JSONHandler();
        _d_Items = V_LoadItems();
    }

    private D_Items V_LoadItems()
    {
        string baseDir = Path.Combine(Application.persistentDataPath, itemsFolderPath);

        if (!Directory.Exists(baseDir))
        {
            Debug.LogError("Items directory does not exist!");
            return new D_Items { Items = new List<D_Item>() }; 
        }

        List<D_Item> items = new List<D_Item>();

        string[] itemDirectories = Directory.GetDirectories(baseDir);


        foreach (string itemDir in itemDirectories)
        {
            string itemName = Path.GetFileName(itemDir);

            string[] imageFiles = Directory.GetFiles(itemDir, "*.png");

            if (imageFiles.Length > 0)
            {
                string imagePath = imageFiles[0];

                D_Item newItem = new D_Item
                {
                    Name = itemName,
                    Type = E_ItemType.Weapon, //default type
                    Img = Path.GetFileName(imagePath)
                };

                items.Add(newItem);
            }
        }

        D_Items dItems = new D_Items { Items = items };

        Debug.Log("Items loaded successfully.");

        _jsonHandler.V_SaveDataToJSONFile(itemsFolderPath + ".json", dItems);

        return dItems;
    }
}