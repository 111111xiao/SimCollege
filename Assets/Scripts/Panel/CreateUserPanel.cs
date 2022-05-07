using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreateUserPanel : BasePanel
{
    private GameObject selectStory;
    private GameObject selectOther;
    private GameObject userView;
    private Text storyTitle;
    private GameObject storySelectBox;
    private Text storyContent;
    private Text otherTitle;
    private GameObject otherSelectBox;
    private Text otherDescribe;
    private GameObject otherConfirmBtn;
    private RectTransform dataRectTransform;
    private Text otherConfirmBtnText;

    private int currentOtherIndex = 0;
    private int currentStoryIndex = 0;
    private int currentIndex = 0;

    private bool isEnd = false;

    private CreateUserManager createUserManager;
    private GameObject[] btnStoryList;
    private GameObject[] btnOtherList;
    private List<Tuple<UnityAction, string, int>> pool;
    private UnityAction redayCall;


    public override void Init()
    {
        Debug.Log("init");
        selectStory = GameObject.Find("SelectStory");
        selectOther = GameObject.Find("SelectOther");
        userView = GameObject.Find("User");
        dataRectTransform = GameObject.Find("User/Data").GetComponent<RectTransform>();
        Debug.Log(selectStory);
        storyTitle = GameObject.Find("SelectStory/Title").GetComponent<Text>();
        storySelectBox = GameObject.Find("SelectStory/SelectBox");
        storyContent = GameObject.Find("SelectStory/Content").GetComponent<Text>();
        otherTitle = GameObject.Find("SelectOther/Title").GetComponent<Text>();
        otherSelectBox = GameObject.Find("SelectOther/SelectBox");
        otherDescribe = GameObject.Find("SelectOther/Describe").GetComponent<Text>();
        otherConfirmBtn = GameObject.Find("SelectOther/ConfirmBtn");
        otherConfirmBtnText = GameObject.Find("SelectOther/ConfirmBtn/Text").GetComponent<Text>();

        createUserManager = new CreateUserManager();

        btnStoryList = new GameObject[6];
        btnOtherList = new GameObject[3];
        pool = new List<Tuple<UnityAction, string, int>>();
    }

    private void OnShowUserData(){
        GameObject.Find("User/Data/Energy/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Energy);
        GameObject.Find("User/Data/Mood/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Mood);
        GameObject.Find("User/Data/Charm/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Charm);
        GameObject.Find("User/Data/Pressure/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Pressure);
        GameObject.Find("User/Data/Vanity/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Vanity);
        GameObject.Find("User/Data/Artistic/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Artistic);
        GameObject.Find("User/Data/Talent/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Talent);
        GameObject.Find("User/Data/Luck/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Luck);
        GameObject.Find("User/Data/Diligence/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Diligence);
        GameObject.Find("User/Data/Constitution/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Constitution);
        GameObject.Find("User/Data/Knowledge/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Knowledge);
        GameObject.Find("User/Data/Social/Value").GetComponent<Text>().text = CommonManager.AddQualityColorByDataType(PlayerDataType.Social);
        LayoutRebuilder.ForceRebuildLayoutImmediate(userView.GetComponent<RectTransform>());
    }
    
    public override void OnEnter()
    {
        if (currentIndex == 0)
        {
            selectStory.gameObject.SetActive(true);
            selectOther.gameObject.SetActive(false);
            ShowStorySelectedBox();
        }
        else
        {
            selectStory.gameObject.SetActive(false);
            selectOther.gameObject.SetActive(true);
            otherDescribe.text = "";
            ShowOtherSelectedBox();
        }

        OnShowUserData();
        LayoutRebuilder.ForceRebuildLayoutImmediate(dataRectTransform);
    }

    public override void AddListener()
    {
        EventCenter.AddListener(EventType.CreateUserNextStory, OnCreateUserNext);
        EventCenter.AddListener<UnityAction, string>(EventType.CreateUserNextTalent, OnCreateUserTalent);
    }

    public void ShowStorySelectedBox()
    {
        UnityAction[] actionList = new UnityAction[6];
        string[] descList = new string[6];
        string story = createUserManager.GetStoryByIndex(currentStoryIndex, actionList, descList);
        for (int i = 0; i < btnStoryList.Length; i++)
        {
            btnStoryList[i] = storySelectBox.transform.Find($"btn{i + 1}").gameObject;
            btnStoryList[i].transform.Find("Text").GetComponent<Text>().text = descList[i];
            AddButtonClick(btnStoryList[i], actionList[i]);
        }

        storyContent.text = story;
    }

    public void ShowOtherSelectedBox()
    {
        if (!isEnd)
        {
            otherTitle.text = "选择天赋";
            otherConfirmBtnText.text = "确认";
            List<Tuple<UnityAction, string, int>> data = createUserManager.GetTalentList();
            Debug.Log($"data{data.Count}");
            //var dataSort = data.OrderBy(a => a.Item3).ToList();
            pool.Clear();
            while (pool.Count < 3)
            {
                int key = Random.Range(0, data.Count);
                if (!pool.Exists(t => Equals(t, data[key])))
                {
                    pool.Add(data[key]);
                }
            }
            for (int i = 0; i < btnOtherList.Length; i++)
            {
                btnOtherList[i] = otherSelectBox.transform.Find($"btn{i + 1}").gameObject;
                btnOtherList[i].transform.Find("Text").GetComponent<Text>().text = pool[i].Item2;
                AddButtonClick(btnOtherList[i], pool[i].Item1);
            }
        }
        else
        {
            otherTitle.text = "完成创建角色";
            for (int i = 0; i < btnOtherList.Length; i++)
            {
                btnOtherList[i] = otherSelectBox.transform.Find($"btn{i + 1}").gameObject;
                btnOtherList[i].SetActive(false);
            }
            otherConfirmBtnText.text = "完成";
            RemoveAllButtonClickListener(otherConfirmBtn);
            AddButtonClick(otherConfirmBtn, OnConfirmBtnClick);
        }
    }

    public void OnCreateUserTalent(UnityAction call, string title)
    {
        redayCall = call;
        RemoveAllButtonClickListener(otherConfirmBtn);
        AddButtonClick(otherConfirmBtn, RefreshConfirmState);
        otherDescribe.text = title;
    }

    public void RefreshConfirmState()
    {
        redayCall();
        for (int i = 0; i < btnOtherList.Length; i++)
        {
            RemoveAllButtonClickListener(btnOtherList[i]);
        }

        currentOtherIndex += 1;
        if (currentOtherIndex >= 3)
        {
            isEnd = true;
        }
        OnEnter();
    }

    public void OnCreateUserNext()
    {
        UnityAction[] actionList = new UnityAction[6];
        string[] descList = new string[6];
        createUserManager.GetStoryByIndex(currentStoryIndex, actionList, descList);
        for (int i = 0; i < btnStoryList.Length; i++)
        {
            RemoveButtonClick(btnStoryList[i], actionList[i]);
        }

        currentStoryIndex += 1;
        if (currentStoryIndex >= 4)
        {
            currentIndex = 1;
        }
        OnEnter();
    }

    public void OnConfirmBtnClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
    }

    public override void OnPause()
    {
    }

    public override void OnExit()
    {
        EventCenter.RemoveListener(EventType.CreateUserNextStory, OnCreateUserNext);
        EventCenter.RemoveListener<UnityAction, string>(EventType.CreateUserNextTalent, OnCreateUserTalent);
        createUserManager.ResetTalentState();
        Debug.Log("���ٴ�����ɫ");
        Destroy(this.gameObject);
    }
}
