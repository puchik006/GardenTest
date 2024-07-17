using System.IO;
using UnityEngine;

public class scr_Media_ImageLoader
{
    public Sprite GetSpriteFromPath(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError($"File not found at path: {filePath}");
            return null;
        }

        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

        return sprite;
    }
}