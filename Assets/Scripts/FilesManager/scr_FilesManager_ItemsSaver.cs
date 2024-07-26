using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// This script is imitate work of downloading items images from server
/// </summary>
public class scr_FilesManager_ItemsSaver: MonoBehaviour
{
    [SerializeField] private List<Sprite> _spitesToLoad;
    private string _itemsFolderPath = "Items";
    private scr_Media_ImageSaver _saver = new();

    public void V_SaveAllItems()
    {
        foreach (var sprite in _spitesToLoad)
        {
            var path = Path.Combine(Application.persistentDataPath, _itemsFolderPath, sprite.name);
            _saver.V_SaveSpriteAsPNG(sprite, path, sprite.name);
        }
    }
}