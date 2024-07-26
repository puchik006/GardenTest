using System.IO;
using UnityEngine;

public class scr_FileManager_JSONHandler
{
    public T V_ReadDataFromJSONFile<T>(string fileName) where T : new()
    {
        var wayDir = $"{Application.persistentDataPath}/";

        var fileDir = Path.Combine(wayDir, fileName);

        if (File.Exists(fileDir))
        {
            Debug.Log($"File exists {fileDir}");
            string jsonContent = File.ReadAllText(fileDir);
            return JsonUtility.FromJson<T>(jsonContent);
        }
        else
        {
            Debug.Log($"File does not exist {fileDir}");
            return new T();
        }
    }

    public void V_SaveDataToJSONFile<T>(string fileName, T jsonObject)
    {
        var wayDir = $"{Application.persistentDataPath}/";

        string jsonContent = JsonUtility.ToJson(jsonObject, true);
        var filePath = Path.Combine(wayDir, fileName);
        File.WriteAllText(filePath, jsonContent);
    }

    public bool Is_JSON_Exist(string fileName)
    {
        var wayDir = $"{Application.persistentDataPath}/";
        var fileDir = Path.Combine(wayDir, fileName);

        return File.Exists(fileDir);
    }
}
