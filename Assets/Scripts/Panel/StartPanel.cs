using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel
{
    private CanvasGroup canvasGroup;
    private GameObject btnStart;
    private GameObject btnLoad;
    private GameObject btnQuit;
    public override void Init()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        btnStart = GameObject.Find("btnBox/Image/btnStart");
        btnLoad = GameObject.Find("btnBox/Image/btnLoad");
        btnQuit = GameObject.Find("btnBox/Image/btnQuit");
    }

    public override void AddListener()
    {
        AddButtonClick(btnStart, OnStartBtnClick);
        AddButtonClick(btnLoad, OnLoadBtnClick);
        AddButtonClick(btnQuit, OnQuitBtnClick);
    }

    public void OnQuitBtnClick()
    {
        GameManager.Instance.ExitGame();
    }
    public void OnStartBtnClick()
    {
        GameManager.Instance.ResetData();
        UIManager.Instance.PushPanel(UIPanelType.CreateUserPanel);
    }
    public void OnLoadBtnClick()
    {
        //PlayerManager.Instance.Init();
        PlayerManager.Instance.Load();
        UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }
    
}
