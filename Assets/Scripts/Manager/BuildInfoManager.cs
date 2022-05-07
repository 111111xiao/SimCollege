using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildInfoManager
{
    /// <summary>
    /// 点击事件 按钮标题
    /// </summary>
    /// <returns></returns>
    public List<Tuple<UnityAction, string>> GetRoomSelectList()
    {
        List<Tuple<UnityAction, string>> data =
            new List<Tuple<UnityAction, string>>();
        data.Add(new Tuple<UnityAction,  string>
            (SelectManager.StudyInRoom.ClickFunc,  SelectManager.StudyInRoom.title ));
        data.Add(new Tuple<UnityAction,  string>
            (SelectManager.DeckSelfStudy.ClickFunc,  SelectManager.DeckSelfStudy.title ));
        return data;
    }
    public List<Tuple<UnityAction, string>> GetShopSelectList()
    {
        List<Tuple<UnityAction, string>> data =
            new List<Tuple<UnityAction, string>>();
        data.Add(new Tuple<UnityAction,  string>
            (SelectManager.ShopBuyNiceCloth.ClickFunc,  SelectManager.ShopBuyNiceCloth.title ));
        return data;
    }
    public List<Tuple<UnityAction, string>> GetBookSelectList()
    {
        List<Tuple<UnityAction, string>> data =
            new List<Tuple<UnityAction, string>>();
        data.Add(new Tuple<UnityAction,  string>
            (SelectManager.BookWatchNovel.ClickFunc,  SelectManager.BookWatchNovel.title ));
        return data;
    }
    public List<Tuple<UnityAction, string>> GetDeckSelectList()
    {
        List<Tuple<UnityAction, string>> data =
            new List<Tuple<UnityAction, string>>();
        data.Add(new Tuple<UnityAction,  string>
            (SelectManager.DeckSelfStudy.ClickFunc,  SelectManager.DeckSelfStudy.title ));
        return data;
    }
}