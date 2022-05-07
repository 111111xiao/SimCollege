using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutPanel : BasePanel
{
    private GameObject btnShop;
    private GameObject btnSchool;
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
    private GameObject btnOutBackToMain;
    private RectTransform dataRectTransform;
    public override void Init()
    {
        btnSchool = GameObject.Find("btnSchool");
        btnShop = GameObject.Find("btnShop");
        btnOutBackToMain = GameObject.Find("btnOutBackToMain");

        dataRectTransform = GameObject.Find("User/Data").GetComponent<RectTransform>();

        leftRound = GameObject.Find("User/Data/Round/Value").GetComponent<Text>();
        energy = GameObject.Find("User/Data/Energy/Value").GetComponent<Text>();
        mood = GameObject.Find("User/Data/Mood/Value").GetComponent<Text>();
        charm = GameObject.Find("User/Data/Charm/Value").GetComponent<Text>();
        preassure = GameObject.Find("User/Data/Pressure/Value").GetComponent<Text>();
        vanity = GameObject.Find("User/Data/Vanity/Value").GetComponent<Text>();
        artistic = GameObject.Find("User/Data/Artistic/Value").GetComponent<Text>();
        talent = GameObject.Find("User/Data/Talent/Value").GetComponent<Text>();
        luck = GameObject.Find("User/Data/Luck/Value").GetComponent<Text>();
        diligence = GameObject.Find("User/Data/Diligence/Value").GetComponent<Text>();
        constitution = GameObject.Find("User/Data/Constitution/Value").GetComponent<Text>();
        konwledge = GameObject.Find("User/Data/Knowledge/Value").GetComponent<Text>();
        social = GameObject.Find("User/Data/Social/Value").GetComponent<Text>();
    }

    public override void AddListener()
    {
        AddButtonClick(btnShop, OnShopClick);
        AddButtonClick(btnSchool, OnSchoolClick);
        AddButtonClick(btnOutBackToMain, OnBackToMainClick);
    }
    public void OnSchoolClick()
    {
        Debug.Log("点击学校");
        UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
    }
    public void OnShopClick()
    {
        Debug.Log("点击商店");
        UIManager.Instance.PushPanel(UIPanelType.BuildInfoPopup, ActivityTypes.Shop);
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
