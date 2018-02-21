using System.Diagnostics;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class ExplorerShower
{
    static ExplorerShower()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
    }

    private static void OnProjectWindowItemOnGUI(string guid, Rect selectionRect) {
        var rect = selectionRect;
        rect.width = 20;
        rect.x = selectionRect.xMax - 20;
        if(GUI.Button(rect, "!"))
        {
            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
            assetPath = assetPath.Replace("/", "\\");
            Process.Start("explorer.exe", "/select," + assetPath);
        }
    }
}