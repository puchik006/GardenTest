﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// This script provides posibility to create JSON for all items according files in certain folder
/// </summary>
public class scr_FileManager_ItemsLoader : MonoBehaviour
{
    [SerializeField] private D_Items _d_Items;
    private string _itemsFolderPath = "Items";
    private scr_FileManager_JSONHandler _jsonHandler = new();

    public void V_LoadItemsFromFolders()
    {
        _d_Items = GetItems();
    }

    public void V_SaveItemsToFile()
    {
        _jsonHandler.V_SaveDataToJSONFile(_itemsFolderPath + ".json", _d_Items);
        Debug.Log("Items saved to file.");
    }

    private D_Items GetItems()
    {
        string baseDir = Path.Combine(Application.persistentDataPath, _itemsFolderPath);

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

        return dItems;
    }
}
