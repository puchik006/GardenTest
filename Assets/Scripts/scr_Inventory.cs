using System.IO;
using UnityEngine;
using static scr_General;

public class scr_Inventory : MonoBehaviour
{
    [SerializeField] private D_Inventory _inventory;
    private string _str_ImagePattern = "*.png";

    private void Start()
    {
        V_CheckLocalDB();
    }

    public void V_CheckLocalDB()
    {
        // 1) Check if main folder exist
        var wayDir = $"{Application.persistentDataPath}/";

        if (!Directory.Exists(wayDir))
        {
            Directory.CreateDirectory(wayDir);
            Debug.Log($"Directory created at: {wayDir}");
        }
        else
        {
            Debug.Log($"Directory already exists at: {wayDir}");
        }

        // 2) Read local data
        var fileDir = Path.Combine(wayDir, m_General.GET_InventoryName);

        if (File.Exists(fileDir))
        {
            Debug.Log("Inventory exist");
            string jsonContent = File.ReadAllText(fileDir);
            _inventory = JsonUtility.FromJson<D_Inventory>(jsonContent);
        }
        else
        {
            Debug.Log("Inventory not exist");
        };

    }

    public void V_SaveLocalData()
    {
        // 3) Save local JSON
        var wayDir = $"{Application.persistentDataPath}/";

        string jsonContent = JsonUtility.ToJson(_inventory, true);
        var filePath = Path.Combine(wayDir, m_General.GET_InventoryName);
        File.WriteAllText(filePath, jsonContent);
    }

    string str_ReturnFileNameFromPath(string path, string filePattern)
    {
        string[] files = Directory.GetFiles(path, filePattern);

        if (files.Length > 0)
        {
            string fileName = Path.GetFileName(files[0]);
            return fileName;
        }
        else
        {
            Debug.Log($"No {filePattern} files found in the {path}");
            return null;
        }
    }
}