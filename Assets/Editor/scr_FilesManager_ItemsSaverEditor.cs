using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(scr_FilesManager_ItemsSaver))]
public class scr_FilesManager_ItemsSaverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        scr_FilesManager_ItemsSaver script = (scr_FilesManager_ItemsSaver)target;

        if (GUILayout.Button("Save all items"))
        {
            script.V_SaveAllItems();
        }

    }
}
