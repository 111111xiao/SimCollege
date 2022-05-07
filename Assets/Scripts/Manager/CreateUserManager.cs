using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CreateUserManager
{
    public string GetStoryByIndex(int index, UnityAction[] actionList, string[] descList)
    {
        string story = "";
        if (index == 0){
            actionList[0] = SelectManager.CreatUser01A.ClickFunc;
            descList[0] = SelectManager.CreatUser01A.desc;
            actionList[1] = SelectManager.CreatUser01B.ClickFunc;
            descList[1] = SelectManager.CreatUser01B.desc;
            actionList[2] = SelectManager.CreatUser01C.ClickFunc;
            descList[2] = SelectManager.CreatUser01C.desc;
            actionList[3] = SelectManager.CreatUser01D.ClickFunc;
            descList[3] = SelectManager.CreatUser01D.desc;
            actionList[4] = SelectManager.CreatUser01E.ClickFunc;
            descList[4] = SelectManager.CreatUser01E.desc;
            actionList[5] = SelectManager.CreatUser01F.ClickFunc;
            descList[5] = SelectManager.CreatUser01F.desc;
            story = "“一日之计在于晨”每个人不同的人生路也从小开始决定。出生后的第一个生日你在不同的路中毅然决然的决定学会 : ";
        }
        else if(index == 1)
        {
            actionList[0] = SelectManager.CreatUser02A.ClickFunc;
            descList[0] = SelectManager.CreatUser02A.desc;
            actionList[1] = SelectManager.CreatUser02B.ClickFunc;
            descList[1] = SelectManager.CreatUser02B.desc;
            actionList[2] = SelectManager.CreatUser02C.ClickFunc;
            descList[2] = SelectManager.CreatUser02C.desc;
            actionList[3] = SelectManager.CreatUser02D.ClickFunc;
            descList[3] = SelectManager.CreatUser02D.desc;
            actionList[4] = SelectManager.CreatUser02E.ClickFunc;
            descList[4] = SelectManager.CreatUser02E.desc;
            actionList[5] = SelectManager.CreatUser02F.ClickFunc;
            descList[5] = SelectManager.CreatUser02F.desc;
            story = "上了小学，班里的同学开始展现出各异的天赋，你也想在同学之中展现自己的特色于是乎你将大部分时间花在 : ";
        }
        else if (index == 2)
        {
            actionList[0] = SelectManager.CreatUser03A.ClickFunc;
            descList[0] = SelectManager.CreatUser03A.desc;
            actionList[1] = SelectManager.CreatUser03B.ClickFunc;
            descList[1] = SelectManager.CreatUser03B.desc;
            actionList[2] = SelectManager.CreatUser03C.ClickFunc;
            descList[2] = SelectManager.CreatUser03C.desc;
            actionList[3] = SelectManager.CreatUser03D.ClickFunc;
            descList[3] = SelectManager.CreatUser03D.desc;
            actionList[4] = SelectManager.CreatUser03E.ClickFunc;
            descList[4] = SelectManager.CreatUser03E.desc;
            actionList[5] = SelectManager.CreatUser03F.ClickFunc;
            descList[5] = SelectManager.CreatUser03F.desc;
            story = "初中生活开始了之后，你的课余时间也变得多了一些，你可以自由安排一部分时间。你的生活开始多姿多彩起来，你在丰富的选择中决定 : ";
        }
        else if (index == 3)
        {
            actionList[0] = SelectManager.CreatUser04A.ClickFunc;
            descList[0] = SelectManager.CreatUser04A.desc;
            actionList[1] = SelectManager.CreatUser04B.ClickFunc;
            descList[1] = SelectManager.CreatUser04B.desc;
            actionList[2] = SelectManager.CreatUser04C.ClickFunc;
            descList[2] = SelectManager.CreatUser04C.desc;
            actionList[3] = SelectManager.CreatUser04D.ClickFunc;
            descList[3] = SelectManager.CreatUser04D.desc;
            actionList[4] = SelectManager.CreatUser04E.ClickFunc;
            descList[4] = SelectManager.CreatUser04E.desc;
            actionList[5] = SelectManager.CreatUser04F.ClickFunc;
            descList[5] = SelectManager.CreatUser04F.desc;
            story = "高中总被人称作人生转折点，繁重的学业、同桌的暧昧、朋友间的友谊。都将成为你在毕业后津津乐道的回忆，在这至关重要的一段时间内你更倾向于 : ";
        }

        return story;
    }

    public List<Tuple<UnityAction, string, int>> GetTalentList()
    {
        List<Tuple<UnityAction, string, int>> data = new List<Tuple<UnityAction, string, int>>();
        if (!SelectManager.Talent01.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent01.ClickFunc, SelectManager.Talent01.desc, SelectManager.Talent01.quality));
        if (!SelectManager.Talent02.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent02.ClickFunc, SelectManager.Talent02.desc, SelectManager.Talent02.quality));
        if (!SelectManager.Talent03.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent03.ClickFunc, SelectManager.Talent03.desc, SelectManager.Talent03.quality));
        if (!SelectManager.Talent04.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent04.ClickFunc, SelectManager.Talent04.desc, SelectManager.Talent04.quality));
        if (!SelectManager.Talent05.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent05.ClickFunc, SelectManager.Talent05.desc, SelectManager.Talent05.quality));
        if (!SelectManager.Talent06.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent06.ClickFunc, SelectManager.Talent06.desc, SelectManager.Talent06.quality));
        if (!SelectManager.Talent07.used)
            data.Add(new Tuple<UnityAction, string, int>(SelectManager.Talent07.ClickFunc, SelectManager.Talent07.desc, SelectManager.Talent07.quality));

        return data;
    }

    public void ResetTalentState()
    {
        SelectManager.Talent01.used = false;
        SelectManager.Talent02.used = false;
        SelectManager.Talent03.used = false;
        SelectManager.Talent04.used = false;
        SelectManager.Talent05.used = false;
        SelectManager.Talent06.used = false;
    }
}
