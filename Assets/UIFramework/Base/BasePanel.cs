using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    public void AddButtonClick(GameObject go, UnityAction call)
    {
        Button btn = go.GetComponent<Button>();
        btn.onClick.AddListener(call);
    }

    public virtual void Init()
    {

    }
    public virtual void AddListener()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnPause()
    {

    }

    public virtual void OnResume()
    {

    }

    public virtual void OnExit()
    {

    }

    private void Awake()
    {
        Init();
        AddListener();
    }
}
