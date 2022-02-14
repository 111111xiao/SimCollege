﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollegePanel : BasePanel
{
    private GameObject btnNext;
    private Text leftRound;
    public override void Init()
    {
        btnNext = GameObject.Find("btnNext");
        leftRound = GameObject.Find("UserView/Round/Value").GetComponent<Text>();
    }

    public override void AddListener()
    {
        AddButtonClick(btnNext, OnNextClick);
    }

    public void OnNextClick()
    {
        Debug.Log("点击下一回合");
        GameManager.RoundPlus();
        OnEnter();
    }

    public override void OnEnter()
    {
        leftRound.text = GameManager.GetLeftRound().ToString();
    }
}
