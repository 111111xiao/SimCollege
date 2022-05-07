using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TipPopup : BasePanel
{
    private Text title;

    private GameObject close;
    public override void Init()
    {
        close = GameObject.Find("tipBg");
        title = GameObject.Find("title").GetComponent<Text>();
    }

    public override void AddListener()
    {
        AddButtonClick(close, OnCloseBtnClick);
    }
    public void OnCloseBtnClick()
    {
        Debug.Log("关闭Tip");
        UIManager.Instance.PopPanel(UIPanelType.TipPopup);
    }
    public override void OnEnter<T>(T str)
    {
        if (str is string newStr)
        {
            string s = newStr;
            title.text = s;
        }
    }
}
