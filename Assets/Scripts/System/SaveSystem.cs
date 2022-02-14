using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);


        try
        {
            File.WriteAllText(path, json);
            Debug.Log($"Successfully saved data to {path}");
        }
        catch (Exception exception)
        {
            Debug.Log($"Failed to saved data from {path}.\n{exception}");
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (Exception exception)
        {
            Debug.Log($"Failed to load data from {path}.\n{exception}");
            return default;
        }
    }

    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            File.Delete(path);
        }
        catch (Exception exception)
        {
            Debug.Log($"Failed to delete {path}.\n{exception}");
        }
    }
}
