using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;
    [NonSerialized]
    public UIPanelWindowType windowType;
    public string panelTypeString;
    public string path;
    public string windowTypeString;

    public void OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIPanelWindowType window = (UIPanelWindowType)Enum.Parse(typeof(UIPanelWindowType), windowTypeString);
        panelType = type;
        windowType = window;
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}
