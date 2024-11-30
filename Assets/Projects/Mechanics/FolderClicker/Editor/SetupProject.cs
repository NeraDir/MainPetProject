using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[InitializeOnLoad]
public class SetupProject
{
    static SetupProject()
    {
        FolderClickListener.sendDataToSetup += OnGetDataToSetup;
    }

    private static void OnGetDataToSetup(string path)
    {
        if(!SetScenesToBuild(path))
            return;
        if (!SetIconToBuild(path))
            return;
        if (!SetDataToBuild(path))
            return;
        if (!SetPresetsToBuild(path))
            return;
        Debug.Log($"<color=GREEN>SUCCESS PROJECT DATA SETTED</color> by Path {path}");
    }

    private static bool SetScenesToBuild(string path)
    {
        List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>();
        string[] allFiles = AssetDatabase.FindAssets("t:Scene", new[] { path });
        foreach (string guid in allFiles)
        {
            string pathó = AssetDatabase.GUIDToAssetPath(guid);
            scenes.Add(new EditorBuildSettingsScene(pathó, true));
        }
        EditorBuildSettingsScene loadScene = scenes.Find(x => x.path.ToLower().Contains("load"));
        if (loadScene != null)
        {
            scenes.Remove(loadScene);
            scenes.Insert(0, loadScene);
        }
        else
        {
            EditorBuildSettingsScene mainScene = scenes.Find(x => x.path.ToLower().Contains("main"));
            if (mainScene != null)
            {
                scenes.Remove(mainScene);
                scenes.Insert(0, mainScene);
            }
        }
        EditorBuildSettings.scenes = scenes.ToArray();
        return true;
    }

    private static bool SetIconToBuild(string path)
    {
        string[] texturesPaths = AssetDatabase.FindAssets("t:Texture2D", new[] { path });
        Texture2D icon = null;
        foreach (string item in texturesPaths)
        {
            string pathó = AssetDatabase.GUIDToAssetPath(item);
            if (pathó.ToLower().Contains("icon"))
            {
                icon = AssetDatabase.LoadAssetAtPath<Texture2D>(pathó);
                break;
            }
        }

        Texture2D[] icons = { icon };
        PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Unknown, icons);
        return true;
    }

    private static bool SetDataToBuild(string path)
    {
        ProjectData data = new ProjectData();
        string[] texturesPaths = AssetDatabase.FindAssets("t:TextAsset", new[] { path });
        foreach (string item in texturesPaths)
        {
            string pathó = AssetDatabase.GUIDToAssetPath(item);
            if (pathó.Contains("projectData"))
            {
                string dataJson = AssetDatabase.LoadAssetAtPath<TextAsset>(pathó).ToString();
                data = JsonConvert.DeserializeObject<ProjectData>(dataJson);
                break;
            }
        }
        PlayerSettings.productName = data.name;
        PlayerSettings.companyName = data.bundle.Split('.')[2];
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS,data.bundle);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, data.bundle);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Standalone, data.bundle);
        PlayerSettings.bundleVersion = data.version;
        return true;
    }

    private static bool SetPresetsToBuild(string path)
    {
        string[] texturesPaths = AssetDatabase.FindAssets("t:UniversalRenderPipelineAsset", new[] { path });
        UniversalRenderPipelineAsset piplinePreset = null;
        foreach (string item in texturesPaths)
        {
            string pathó = AssetDatabase.GUIDToAssetPath(item);
            piplinePreset = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(pathó);
            if (piplinePreset != null)
            {
                break;
            }
        }
        GraphicsSettings.defaultRenderPipeline = piplinePreset;
        return true;
    }
}

public struct ProjectData
{
    public string name { get; set; }
    public string bundle { get; set; }
    public string version { get; set; }
    public string store { get; set; }
}
