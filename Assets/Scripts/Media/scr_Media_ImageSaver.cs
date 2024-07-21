using System.IO;
using UnityEngine;

public class scr_Media_ImageSaver
{
    public void V_SaveSpriteAsPNG(Sprite sprite, string folderPath, string fileName)
    {
        // Create the folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Extract the texture from the sprite
        Texture2D texture = sprite.texture;
        Rect rect = sprite.textureRect;
        Texture2D croppedTexture = new Texture2D((int)rect.width, (int)rect.height);

        // Copy the pixels from the original texture to the new texture
        Color[] pixels = texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        // Encode the texture to PNG format
        byte[] pngData = croppedTexture.EncodeToPNG();

        // Save the PNG to the specified path
        string filePath = Path.Combine(folderPath, fileName + ".png");
        File.WriteAllBytes(filePath, pngData);

        Debug.Log($"Sprite saved as PNG at: {filePath}");
    }
}
