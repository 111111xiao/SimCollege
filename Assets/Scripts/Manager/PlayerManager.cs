using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private static PlayerManager _instance;
    private PlayerData playerData;
    private Dictionary<PlayerDataType, float> dataDict;
    private Dictionary<PlayerDataType, float> dataLimitDict;

    #region 用户数据
    /// <summary>
    ///  虚荣 才华 天赋 幸运 勤奋
    /// </summary>
    private float _vanity;
    private float _artistic;
    private float _talent;
    private float _luck;
    private float _diligence;

    /// <summary>
    /// 饼状图:体质 知识 社交
    /// </summary>
    private float _constitution;
    private float _knowledge;
    private float _social;

    /// <summary>
    /// 精力 心情 魅力 压力
    /// </summary>
    private float _energy;
    private float _mood;
    private float _charm;
    private float _pressure;

    #endregion

    PlayerManager()
    {
        Init();
    }

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("创建新单例");
                _instance = new PlayerManager();
            }

            return _instance;
        }
    }

    public void Init()
    {
        InitData();
        InitDataDic();
    }

    private void InitData()
    {
        Debug.Log("初始化数据");
        _vanity = 50;
        _artistic = 50;
        _talent = 50;
        _luck = 50;
        _diligence = 50;

        _constitution = 50;
        _knowledge = 50;
        _social = 50;

        _energy = 100;
        _mood = 50;
        _charm = 50;
        _pressure = 0;
    }


    private void ClearData()
    {
        Debug.Log("加载前清空本地数据");
        _vanity = 0;
        _artistic = 0;
        _talent = 0;
        _luck = 0;
        _diligence = 0;

        _constitution = 0;
        _knowledge = 0;
        _social = 0;

        _energy = 0;
        _mood = 0;
        _charm = 0;
        _pressure = 0;
    }

    private void InitDataDic()
    {
        dataDict = new Dictionary<PlayerDataType, float>();

        dataDict.Add(PlayerDataType.Vanity, _vanity);
        dataDict.Add(PlayerDataType.Artistic, _artistic);
        dataDict.Add(PlayerDataType.Talent, _talent);
        dataDict.Add(PlayerDataType.Luck, _luck);
        dataDict.Add(PlayerDataType.Diligence, _diligence);

        dataDict.Add(PlayerDataType.Constitution, _constitution);
        dataDict.Add(PlayerDataType.Knowledge, _knowledge);
        dataDict.Add(PlayerDataType.Social, _social);

        dataDict.Add(PlayerDataType.Energy, _energy);
        dataDict.Add(PlayerDataType.Mood, _mood);
        dataDict.Add(PlayerDataType.Charm, _charm);
        dataDict.Add(PlayerDataType.Pressure, _pressure);

        dataLimitDict = new Dictionary<PlayerDataType, float>();
    }

    public void ChangeAllData(float value)
    {
        ChangeData(PlayerDataType.Vanity, value);
        ChangeData(PlayerDataType.Artistic, value);
        ChangeData(PlayerDataType.Talent, value);
        ChangeData(PlayerDataType.Luck, value);
        ChangeData(PlayerDataType.Diligence, value);
        ChangeData(PlayerDataType.Constitution, value);
        ChangeData(PlayerDataType.Knowledge, value);
        ChangeData(PlayerDataType.Social, value);
    }

    public void ChangeData(PlayerDataType type, float value)
    {
        if (dataDict.ContainsKey(type))
        {
            Debug.Log($"{type}添加前{dataDict[type]}");
            if (dataDict[type] + value > 100)
            {
                dataDict[type] = 100;
            }
            else if (dataDict[type] + value < 0)
            {
                dataDict[type] = 0;
            }
            else
            {
                dataDict[type] = dataDict[type] + value;
            }
            Debug.Log($"{type}添加后{dataDict[type]}");
        }
        else
        {
            Debug.Log($"{type}不存在");
        }
    }

    public float GetData(PlayerDataType type)
    {
        if (dataDict.ContainsKey(type))
        {
            return dataDict[type];
        }
        else
        {
            Debug.Log($"{type}不存在");
            return 0;
        }
    }

    public void Save()
    {
        playerData = new PlayerData();
        playerData.SaveByJson();
    }

    public void Load()
    {
        ClearData();
        InitDataDic();
        playerData = new PlayerData();
        playerData.LoadFromJson();
    }

    public void DeleteSaveFile()
    {
        playerData = new PlayerData();
        playerData.DeleteFile();
    }
}
