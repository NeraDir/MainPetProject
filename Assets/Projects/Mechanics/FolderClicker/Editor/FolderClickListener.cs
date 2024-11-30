using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class FolderClickListener
{
    public static Action<string> sendDataToSetup;

    static FolderClickListener()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowGUI;
    }

    private static void OnProjectWindowGUI(string guid, Rect selectionRect)
    {
        Event currentEvent = Event.current;

        if (selectionRect.Contains(currentEvent.mousePosition))
        {
            if (currentEvent.type == EventType.MouseDown && currentEvent.button == 0 && currentEvent.alt)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                if (AssetDatabase.IsValidFolder(path))
                {
                    sendDataToSetup?.Invoke(path);
                    currentEvent.Use();
                }
            }
        }
    }
}
