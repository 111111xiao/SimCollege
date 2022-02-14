using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    private PlayerData playerData;

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerManager();
            }

            return _instance;
        }
    }

    public void Save()
    {
        playerData = new PlayerData();
        playerData.SaveByJson();
    }

    public void Load()
    {
        playerData = new PlayerData();
        playerData.LoadFromJson();
    }
}
