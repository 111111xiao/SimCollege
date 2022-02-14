using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private const string PLAYER_DATA_FILE_NAME = "playerData.sav";

    public void Save()
    {
        SaveByJson();
    }

    public void Load()
    {
        LoadFromJson();
    }

    [Serializable]
    class SaveData
    {
        public int currentRound;
    }


    SaveData SavingData()
    {
        SaveData save = new SaveData();
        save.currentRound = GameManager.CurrentRound;
        return save;
    }
    void LoadingData(SaveData save)
    {
        GameManager.CurrentRound = save.currentRound;
    }
    public void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }
    public void LoadFromJson()
    {
        SaveData save = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        LoadingData(save);
    }
}
