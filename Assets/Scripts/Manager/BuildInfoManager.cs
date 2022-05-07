using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildInfoManager
{
    /// <summary>
    /// ������� ȷ�Ϸ��� ���� ����
    /// </summary>
    /// <returns></returns>
    public List<Tuple<UnityAction, string>> GetRoomSelectList()
    {
        List<Tuple<UnityAction, string>> data =
            new List<Tuple<UnityAction, string>>();
        data.Add(new Tuple<UnityAction,  string>
            (SelectManager.StudyInRoom.ClickFunc,  SelectManager.StudyInRoom.title ));
        return data;
    }
}