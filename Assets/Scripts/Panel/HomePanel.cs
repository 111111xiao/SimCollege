using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : BasePanel
{
    private GameObject btnBook;
    private GameObject btnDeck;
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
    private GameObject btnHomeBackToMain;
    private GameObject btnHomeNext;
    private RectTransform dataRectTransform;
    public override void Init()
    {
        btnBook = GameObject.Find("btnBook");
        btnDeck = GameObject.Find("btnDeck");
        btnHomeBackToMain = GameObject.Find("btnHomeBackToMain");
        btnHomeNext = GameObject.Find("btnHomeNext");

        dataRectTransform = GameObject.Find("UserV/Data").GetComponent<RectTransform>();

        leftRound = GameObject.Find("UserV/Data/Round/Value").GetComponent<Text>();
        energy = GameObject.Find("UserV/Data/Energy/Value").GetComponent<Text>();
        mood = GameObject.Find("UserV/Data/Mood/Value").GetComponent<Text>();
        charm = GameObject.Find("UserV/Data/Charm/Value").GetComponent<Text>();
        preassure = GameObject.Find("UserV/Data/Pressure/Value").GetComponent<Text>();
        vanity = GameObject.Find("UserV/Data/Vanity/Value").GetComponent<Text>();
        artistic = GameObject.Find("UserV/Data/Artistic/Value").GetComponent<Text>();
        talent = GameObject.Find("UserV/Data/Talent/Value").GetComponent<Text>();
        luck = GameObject.Find("UserV/Data/Luck/Value").GetComponent<Text>();
        diligence = GameObject.Find("UserV/Data/Diligence/Value").GetComponent<Text>();
        constitution = GameObject.Find("UserV/Data/Constitution/Value").GetComponent<Text>();
        konwledge = GameObject.Find("UserV/Data/Knowledge/Value").GetComponent<Text>();
        social = GameObject.Find("UserV/Data/Social/Value").GetComponent<Text>();
    }

    public override void AddListener()
    {
        AddButtonClick(btnBook, OnBookClick);
        AddButtonClick(btnDeck, OnDeckClick);
        AddButtonClick(btnHomeBackToMain, OnBackToMainClick);
        AddButtonClick(btnHomeNext, OnNextClick);
    }
    public void OnNextClick()
    {
        Debug.Log("点击下一回合");
        GameManager.RoundPlus();
        OnEnter();
    }
    public void OnBookClick()
    {
        Debug.Log("点击书架");
        UIManager.Instance.PushPanel(UIPanelType.BuildInfoPopup, ActivityTypes.Book);
    }
    public void OnDeckClick()
    {
        Debug.Log("点击书桌");
        UIManager.Instance.PushPanel(UIPanelType.BuildInfoPopup, ActivityTypes.Deck);
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
