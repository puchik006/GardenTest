using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(scr_ItemsLoader))]
public class scr_ItemsLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        scr_ItemsLoader script = (scr_ItemsLoader)target;
        if (GUILayout.Button("Save Items to File"))
        {
            script.V_SaveItemsToFile();
        }
    }
}
