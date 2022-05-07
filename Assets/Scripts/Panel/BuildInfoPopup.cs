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

    private BuildInfoManager buildInfoManager;
    private GameObject selectBox;
    private List<Tuple<UnityAction, string>> data;

    private GameObject[] btnList;
    public override void Init()
    {
        closeBtn = GameObject.Find("bg2/closeBtn");
        selectBox = GameObject.Find("bg2/SelectBox");
        btnConfirm = GameObject.Find("bg2/btnConfirm");
        desc = GameObject.Find("bg2/desc").GetComponent<Text>();
        buildInfoManager = new BuildInfoManager();
        btnList = new GameObject[6];
    }

    public override void AddListener()
    {
        AddButtonClick(closeBtn, OnCloseBtnClick);
        EventCenter.AddListener<UnityAction, string>(EventType.RoomStudy, OnRoomStudy);
    }

    public override void OnEnter<T>(T type)
    {
        print($"type is {type}");
        if (type is ActivityTypes newType)
        {
            ActivityTypes tp = newType;
            ShowSelectBox(tp);
        }
    }

    public void OnCloseBtnClick(){
        Debug.Log("点击关闭按钮");
        UIManager.Instance.PopPanel(UIPanelType.BuildInfoPopup);
    }

    public void OnRoomStudy(UnityAction call, string studyDesc)
    {
        RemoveAllButtonClickListener(btnConfirm);
        AddButtonClick(btnConfirm, call);
        desc.text = studyDesc;
    }

    public void ShowSelectBox(ActivityTypes type)
    {
        if (type == ActivityTypes.Room){
            data = buildInfoManager.GetRoomSelectList();
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
        EventCenter.RemoveListener<UnityAction, string>(EventType.RoomStudy, OnRoomStudy);
        base.OnExit();
    }
}
