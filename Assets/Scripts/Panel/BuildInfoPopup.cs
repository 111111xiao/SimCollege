using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildInfoPopup : BasePanel
{
    private GameObject closeBtn;
    private GameObject btnConfirm;
    private Text desc;
    private Text useful;

    private BuildInfoManager buildInfoManager;
    private GameObject selectBox;
    private List<Tuple<UnityAction, string>> data;

    private GameObject[] btnList;

    private UnityAction readyCall;
    private ActivityTypes tp;
    public override void Init()
    {
        closeBtn = GameObject.Find("bg2/closeBtn");
        selectBox = GameObject.Find("bg2/SelectBox");
        btnConfirm = GameObject.Find("bg2/btnConfirm");
        desc = GameObject.Find("bg2/desc").GetComponent<Text>();
        useful = GameObject.Find("bg2/useful").GetComponent<Text>();
        buildInfoManager = new BuildInfoManager();
        btnList = new GameObject[6];
    }

    public override void AddListener()
    {
        AddButtonClick(closeBtn, OnCloseBtnClick);

        EventCenter.AddListener<UnityAction, List<string>>(EventType.SelectUnityActionAndStringList, OnSelectUnityActionAndStringList);

    }

    public override void OnEnter<T>(T type)
    {
        print($"type is {type}");
        if (type is ActivityTypes newType)
        {
            tp = newType;
            ShowSelectBox(tp);
        }
    }

    public void OnCloseBtnClick(){
        Debug.Log("点击关闭按钮");
        UIManager.Instance.PopPanel(UIPanelType.BuildInfoPopup);
    }

    public void OnSelectUnityActionAndStringList(UnityAction call, List<string> list)
    {
        readyCall = call;
        RemoveAllButtonClickListener(btnConfirm);
        AddButtonClick(btnConfirm, OnConfirmBtnClick);
        desc.text = list[0];
        useful.text = list[1];
    }

    public void OnConfirmBtnClick(){
        readyCall();
        OnEnter(tp);
    }

    public void ShowSelectBox(ActivityTypes type)
    {
        if (type == ActivityTypes.Room){
            desc.text = "欢迎来到宿舍";
            data = buildInfoManager.GetRoomSelectList();
        }else if (type == ActivityTypes.Shop){
            desc.text = "欢迎来到商店";
            data = buildInfoManager.GetShopSelectList();
        }else if (type == ActivityTypes.Book){
            desc.text = "这里是简简单单的书架";
            data = buildInfoManager.GetBookSelectList();
        }else if (type == ActivityTypes.Deck){
            desc.text = "这里是熟悉的书桌";
            data = buildInfoManager.GetDeckSelectList();
        }


        for (int i = 0; i < btnList.Length; i++)
        {
            btnList[i] = selectBox.transform.Find($"btn{i + 1}").gameObject;
            btnList[i].SetActive(false);
        }

        for (int i = 0; i < data.Count; i++)
        {
            btnList[i].SetActive(true);
            btnList[i].transform.Find("Text").GetComponent<Text>().text = data[i].Item2;
            AddButtonClick(btnList[i], data[i].Item1);
        }
    }

    public override void OnExit()
    {
        if (data != null && data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                RemoveButtonClick(btnList[i], data[i].Item1);
            }
        }
        EventCenter.RemoveListener<UnityAction, List<string>>(EventType.SelectUnityActionAndStringList, OnSelectUnityActionAndStringList);
        base.OnExit();
    }
}
