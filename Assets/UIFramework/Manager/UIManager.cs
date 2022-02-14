using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }

            return _instance;
        }
    }

    private Transform canvasTransform;

    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }

            return canvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDictionary;
    private Dictionary<UIPanelType, BasePanel> panelDictionary;
    private Stack<BasePanel> panelStack;

    private UIManager()
    {
        ParseUIPanelTypeJson();
    }

    public void PushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
    }

    public void PopPanel()
    {

        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count <= 0)
        {
            return;
        }

        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();
        if (panelStack.Count <= 0)
        {
            return;
        }
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }

    public BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDictionary == null)
        {
            panelDictionary = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel panel;
        panelDictionary.TryGetValue(panelType, out panel);
        if (panel == null)
        {
            // 找不到面板就实例化面板
            string path = panelPathDictionary.TryGet(panelType);
            //panelPathDictionary.TryGetValue(panelType, out path);
            Debug.Log(path);
            GameObject instancePanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instancePanel.transform.SetParent(CanvasTransform, false);
            panel = instancePanel.GetComponent<BasePanel>();
            panelDictionary.Add(panelType, panel);
        }
        return panel;
    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDictionary = new Dictionary<UIPanelType, string>();
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (var panelInfo in jsonObject.infoList)
        {
            //Debug.Log(panelInfo.panelType);
            //Debug.Log(panelInfo.path);
            panelPathDictionary.Add(panelInfo.panelType, panelInfo.path);
        }
    }

    public void Test()
    {
        string path;
        panelPathDictionary.TryGetValue(UIPanelType.StartPanel, out path);
        Debug.Log(path);
    }
}
