﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel
{
    private CanvasGroup canvasGroup;
    private GameObject btnStart;
    private GameObject btnLoad;
    public override void Init()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        btnStart = GameObject.Find("btnBox/Image/btnStart");
        btnLoad = GameObject.Find("btnBox/Image/btnLoad");
    }

    public override void AddListener()
    {
        AddButtonClick(btnStart, OnStartBtnClick);
        AddButtonClick(btnLoad, OnLoadBtnClick);
    }

    public void OnStartBtnClick()
    {
        GameManager.Instance.ResetData();
        UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
    }
    public void OnLoadBtnClick()
    {
        PlayerManager.Instance.Load();
        UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }
    
}
