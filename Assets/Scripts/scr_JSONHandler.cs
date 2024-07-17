using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class scr_JSONHandler
{
    public T V_ReadDataFromFile<T>(string fileName) where T : new()
    {
        var wayDir = $"{Application.persistentDataPath}/";

        var fileDir = Path.Combine(wayDir, fileName);

        if (File.Exists(fileDir))
        {
            Debug.Log("File exists");
            string jsonContent = File.ReadAllText(fileDir);
            return JsonUtility.FromJson<T>(jsonContent);
        }
        else
        {
            Debug.Log("File does not exist");
            return new T();
        }
    }

    public void V_SaveDataToFile<T>(string fileName, T jsonObject)
    {
        var wayDir = $"{Application.persistentDataPath}/";

        string jsonContent = JsonUtility.ToJson(jsonObject, true);
        var filePath = Path.Combine(wayDir, fileName);
        File.WriteAllText(filePath, jsonContent);
    }


    public void V_CreateJSONFromFiles()
    {
        var wayDir = $"{Application.persistentDataPath}/Items/";

        // 1) Check if main folder exist
        if (!Directory.Exists(wayDir))
        {
            Directory.CreateDirectory(wayDir);
            Debug.Log($"Directory created at: {wayDir}");
        }
        else
        {
            Debug.Log($"Directory already exists at: {wayDir}");
        }

        // 2) Read all themes folders + theme image, then puzzles folders + puzzle images
        foreach (var theme in Directory.GetDirectories(wayDir))
        {
            var itemsFolderName = theme.Split(wayDir)[1];

            var items = new D_Items()
            {
                Items = new List<D_Item>()
            };

            //_d_JSON.Themes.Add(items);

            //foreach (var podcast in Directory.GetDirectories(theme))
            //{
            //    var podcastFolderName = Path.GetFileName(podcast);

            //    _d_JSON.Themes[_d_JSON.Themes.Count - 1].Puzzles.Add(new Dmm_JSON()
            //    {
            //        ID = "",
            //        Name = podcastFolderName,
            //        Img = str_ReturnFileNameFromPath(podcast, _str_ImagePattern),
            //        Ogg = "",
            //        E_Raiting = 0
            //    });
            //}
        }
}
