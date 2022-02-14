using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel
{
    private CanvasGroup canvasGroup;
    private GameObject btnStart;
    public override void Init()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        btnStart = GameObject.Find("btnBox/Image/btnStart");
    }

    public override void AddListener()
    {
        AddButtonClick(btnStart, OnStartBtnClick);
    }

    public void OnStartBtnClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
