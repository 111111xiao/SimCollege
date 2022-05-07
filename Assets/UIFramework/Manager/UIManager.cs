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
    private Dictionary<UIPanelType, PanelInfo> panelPathDictionary;
    private Dictionary<UIPanelType, BasePanel> panelDictionary;
    private Stack<BasePanel> panelStack;

    private UIManager()
    {
        ParseUIPanelTypeJson();
    }

    public void BeforePush(UIPanelType panelType){

        List<UIPanelType> needClearPanelTypes = new List<UIPanelType>();
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if (panelDictionary != null && panelDictionary.Count > 0 && panelPathDictionary.TryGet(panelType).windowType == UIPanelWindowType.Panel)
        {
            foreach (var kvPair in panelDictionary)
            {
                needClearPanelTypes.Add(kvPair.Key);
            }

            foreach (var type in needClearPanelTypes)
            {
                PopPanel(type);
            }
        }

        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

    }

    public void PushPanel(UIPanelType panelType)
    {
        BeforePush(panelType);
        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
    }
    public void PushPanel<T>(UIPanelType panelType, T arg1)
    {
        BeforePush(panelType);
        BasePanel panel = GetPanel(panelType);
        panel.OnEnter(arg1);
        panelStack.Push(panel);
    }

    public void PopPanel(UIPanelType panelType)
    {
        Debug.Log($"PopPanel{panelType}");
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count <= 0)
        {
            return;
        }

        BasePanel topPanel = panelStack.Pop();
        panelDictionary.Remove(panelType);
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

        BasePanel panel = panelDictionary.TryGet(panelType);
        Debug.Log($"try get {panel}");
        if (panel == null)
        {
            // 找不到面板就实例化面板
            string path = panelPathDictionary.TryGet(panelType).path;
            //panelPathDictionary.TryGetValue(panelType, out path);
            Debug.Log(path);
            GameObject instancePanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instancePanel.transform.SetParent(CanvasTransform, false);
            panel = instancePanel.GetComponent<BasePanel>();
            panelDictionary.Add(panelType, instancePanel.GetComponent<BasePanel>());
            Debug.Log($"add panel {panel}");
        }
        return panel;
    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    /// <summary>
    /// 界面路径和界面署于全屏还是窗口
    /// </summary>
    class PanelInfo
    {
        public string path;
        public UIPanelWindowType windowType;

        public PanelInfo(string Path, UIPanelWindowType Type)
        {
            path = Path;
            windowType = Type;
        }
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDictionary = new Dictionary<UIPanelType, PanelInfo>();
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (var panelInfo in jsonObject.infoList)
        {
            //Debug.Log(panelInfo.panelType);
            //Debug.Log(panelInfo.path);
            panelPathDictionary.Add(panelInfo.panelType, new PanelInfo(panelInfo.path, panelInfo.windowType));
        }
    }
    
}
