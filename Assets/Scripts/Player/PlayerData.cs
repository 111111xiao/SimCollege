using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private const string PLAYER_DATA_FILE_NAME = "playerData.sav";

    [Serializable]
    class SaveData
    {
        public int currentRound;

        public float vanity;//虚荣
        public float artistic;//才华
        public float talent;//天赋
        public float luck;//幸运
        public float diligence;//勤奋
        public float constitution;//体质
        public float knowledge;//知识
        public float social;//社交
        public float energy;//精力
        public float mood;//心情
        public float charm;//魅力
        public float pressure;//压力
    }


    SaveData SavingData()
    {
        SaveData save = new SaveData();
        save.currentRound = GameManager.CurrentRound;
        save.vanity = PlayerManager.Instance.GetData(PlayerDataType.Vanity);
        save.artistic = PlayerManager.Instance.GetData(PlayerDataType.Artistic);
        save.talent = PlayerManager.Instance.GetData(PlayerDataType.Talent);
        save.luck = PlayerManager.Instance.GetData(PlayerDataType.Luck);
        save.diligence = PlayerManager.Instance.GetData(PlayerDataType.Diligence);
        save.constitution = PlayerManager.Instance.GetData(PlayerDataType.Constitution);
        save.knowledge = PlayerManager.Instance.GetData(PlayerDataType.Knowledge);
        save.social = PlayerManager.Instance.GetData(PlayerDataType.Social);
        save.energy = PlayerManager.Instance.GetData(PlayerDataType.Energy);
        save.mood = PlayerManager.Instance.GetData(PlayerDataType.Mood);
        save.charm = PlayerManager.Instance.GetData(PlayerDataType.Charm);
        save.pressure = PlayerManager.Instance.GetData(PlayerDataType.Pressure);
        return save;
    }
    void LoadingData(SaveData save)
    {
        GameManager.CurrentRound = save.currentRound;
        PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, save.vanity);
        PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, save.artistic);
        PlayerManager.Instance.ChangeData(PlayerDataType.Talent, save.talent);
        PlayerManager.Instance.ChangeData(PlayerDataType.Luck, save.luck);
        PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, save.diligence);
        PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, save.constitution);
        PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, save.knowledge);
        PlayerManager.Instance.ChangeData(PlayerDataType.Social, save.social);
        PlayerManager.Instance.ChangeData(PlayerDataType.Energy, save.energy);
        PlayerManager.Instance.ChangeData(PlayerDataType.Mood, save.mood);
        PlayerManager.Instance.ChangeData(PlayerDataType.Charm, save.charm);
        PlayerManager.Instance.ChangeData(PlayerDataType.Pressure, save.pressure);
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

    public void DeleteFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
}
