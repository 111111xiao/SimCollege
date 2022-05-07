using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollegePanel : BasePanel
{
    private GameObject btnNext;
    private GameObject btnSave;
    private GameObject btnAdd;
    private GameObject btnRoom;
    private GameObject btnOut;
    private Text leftRound;
    private Text energy;
    private Text mood;
    private Text charm;
    private Text preassure;
    private Text vanity;
    private Text artistic;
    private Text talent;
    private Text luck;
    private Text diligence;
    private Text constitution;
    private Text konwledge;
    private Text social;
    private GameObject btnBackToMain;
    private RectTransform dataRectTransform;
    public override void Init()
    {
        btnNext = GameObject.Find("btnNext");
        btnSave = GameObject.Find("btnSave");
        btnAdd = GameObject.Find("btnAdd");
        btnRoom = GameObject.Find("btnRoom");
        btnOut = GameObject.Find("btnOut");
        btnBackToMain = GameObject.Find("btnBackToMain");

        dataRectTransform = GameObject.Find("UserView/Data").GetComponent<RectTransform>();

        leftRound = GameObject.Find("UserView/Data/Round/Value").GetComponent<Text>();
        energy = GameObject.Find("UserView/Data/Energy/Value").GetComponent<Text>();
        mood = GameObject.Find("UserView/Data/Mood/Value").GetComponent<Text>();
        charm = GameObject.Find("UserView/Data/Charm/Value").GetComponent<Text>();
        preassure = GameObject.Find("UserView/Data/Pressure/Value").GetComponent<Text>();
        vanity = GameObject.Find("UserView/Data/Vanity/Value").GetComponent<Text>();
        artistic = GameObject.Find("UserView/Data/Artistic/Value").GetComponent<Text>();
        talent = GameObject.Find("UserView/Data/Talent/Value").GetComponent<Text>();
        luck = GameObject.Find("UserView/Data/Luck/Value").GetComponent<Text>();
        diligence = GameObject.Find("UserView/Data/Diligence/Value").GetComponent<Text>();
        constitution = GameObject.Find("UserView/Data/Constitution/Value").GetComponent<Text>();
        konwledge = GameObject.Find("UserView/Data/Knowledge/Value").GetComponent<Text>();
        social = GameObject.Find("UserView/Data/Social/Value").GetComponent<Text>();
    }

    public override void AddListener()
    {
        AddButtonClick(btnNext, OnNextClick);
        AddButtonClick(btnSave, OnSaveClick);
        AddButtonClick(btnAdd, OnAddClick);
        AddButtonClick(btnRoom, OnRoomClick);
        AddButtonClick(btnOut, OnOutClick);
        AddButtonClick(btnBackToMain, OnBackToMainClick);
    }
    public void OnOutClick()
    {
        Debug.Log("点击外出");
        UIManager.Instance.PushPanel(UIPanelType.OutPanel);
    }
    public void OnRoomClick()
    {
        Debug.Log("点击宿舍");
        UIManager.Instance.PushPanel(UIPanelType.BuildInfoPopup, ActivityTypes.Room);
    }
    public void OnSaveClick()
    {
        Debug.Log("保存");
        PlayerManager.Instance.Save();
        OnEnter();
    }
    public void OnAddClick()
    {
        int direction = Random.Range(1, 12);
        PlayerDataType type;
        string desc = "";
        int value = Random.Range(-50, 50);
        if (direction == 1)
        {
            type = PlayerDataType.Energy;
            desc = "精力";
        }
        else if (direction == 2)
        {
            type = PlayerDataType.Mood;
            desc = "心情";
        }
        else if (direction == 3)
        {
            type = PlayerDataType.Charm;
            desc = "魅力";
        }
        else if (direction == 4)
        {
            type = PlayerDataType.Vanity;
            desc = "虚荣";
        }
        else if (direction == 5)
        {
            type = PlayerDataType.Talent;
            desc = "天赋";
        }
        else if (direction == 6)
        {
            type = PlayerDataType.Artistic;
            desc = "才华";
        }
        else if (direction == 7)
        {
            type = PlayerDataType.Constitution;
            desc = "体质";
        }
        else if (direction == 8)
        {
            type = PlayerDataType.Pressure;
            desc = "压力";
        }
        else if (direction == 9)
        {
            type = PlayerDataType.Diligence;
            desc = "勤奋";
        }
        else if (direction == 10)
        {
            type = PlayerDataType.Luck;
            desc = "幸运";
        }
        else if (direction == 11)
        {
            type = PlayerDataType.Knowledge;
            desc = "知识";
        }
        else if (direction == 12)
        {
            type = PlayerDataType.Social;
            desc = "社交";
        }
        else
        {
            Debug.Log($"{direction}无对应索引");
            return;
        }

        Debug.Log(desc + $"增加了{value}");
        PlayerManager.Instance.ChangeData(type, value);
        OnEnter();
    }

    public void OnNextClick()
    {
        Debug.Log("点击下一回合");
        GameManager.RoundPlus();
        OnEnter();
    }
    public void OnBackToMainClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.StartPanel);
    }

    public override void OnEnter()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(dataRectTransform);
        leftRound.text = GameManager.GetLeftRound().ToString();

        energy.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Energy);
        mood.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Mood);
        charm.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Charm);
        preassure.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Pressure);
        vanity.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Vanity);
        artistic.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Artistic);
        talent.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Talent);
        luck.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Luck);
        diligence.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Diligence);
        constitution.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Constitution);
        konwledge.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Knowledge);
        social.text = CommonManager.AddQualityColorByDataType(PlayerDataType.Social);
    }

    public override void OnResume()
    {
        base.OnResume();
        OnEnter();
    }
}
