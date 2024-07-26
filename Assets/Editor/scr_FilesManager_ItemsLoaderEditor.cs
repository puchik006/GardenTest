using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(scr_FileManager_ItemsLoader))]
public class scr_FilesManager_ItemsLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        scr_FileManager_ItemsLoader script = (scr_FileManager_ItemsLoader)target;

        if (GUILayout.Button("Load Items from folders"))
        {
            script.V_LoadItemsFromFolders();
        }

        if (GUILayout.Button("Save Items to File"))
        {
            script.V_SaveItemsToFile();
        }
    }
}
