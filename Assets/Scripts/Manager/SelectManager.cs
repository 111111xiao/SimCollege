using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class SelectManager
{
    private static SelectManager _instance;

    public static SelectManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SelectManager();
            }

            return _instance;
        }
    }

    #region 创建角色
    #region 幼儿
    // +7
    public class CreatUser01A
    {
        public static string desc = "吃饭";

        public static void ClickFunc()
        {
            //+5体质+2虚荣
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser01B
    {
        public static string desc = "说话";

        public static void ClickFunc()
        {
            //+7社交
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 7);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser01C
    {
        public static string desc = "涂画";

        public static void ClickFunc()
        {
            //+5才华+2勤奋
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser01D
    {
        public static string desc = "走路";

        public static void ClickFunc()
        {
            //+7体质
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 7);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser01E
    {
        public static string desc = "数钱";

        public static void ClickFunc()
        {
            //+6虚荣+1幸运
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 6);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 1);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser01F
    {
        public static string desc = "识字";

        public static void ClickFunc()
        {
            //+2天赋+3知识+2勤奋
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    #endregion
    #region 小学
    //+15 -5
    public class CreatUser02A
    {
        public static string desc = "做奥数题";

        public static void ClickFunc()
        {
            //勤奋+6知识+5天份+4 社交-3体质-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 6);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 4);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser02B
    {
        public static string desc = "上体育课";

        public static void ClickFunc()
        {
            //体质+8勤奋+3天份+2社交+2 知识-5
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -5);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser02C
    {
        public static string desc = "和小伙伴玩耍";

        public static void ClickFunc()
        {
            //社交+9体质+6 知识-3勤奋-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 6);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser02D
    {
        public static string desc = "做家务换零花钱";

        public static void ClickFunc()
        {
            //勤奋+10体质+3幸运+2 虚荣+3知识-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser02E
    {
        public static string desc = "一个人玩";

        public static void ClickFunc()
        {
            //才华+4天份+4勤奋+4幸运+3 社交-5
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 4);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 4);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 4);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -5);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser02F
    {
        public static string desc = "上美术课";

        public static void ClickFunc()
        {
            //才华+10社交+4幸运+1 知识-3体质-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 4);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 1);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    #endregion
    #region 初中
    //+25 -10
    public class CreatUser03A
    {
        public static string desc = "上网吧";

        public static void ClickFunc()
        {
            //社交+8天份+8幸运+3虚荣+6 体质-5知识-5
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 6);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -5);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser03B
    {
        public static string desc = "打架斗殴";

        public static void ClickFunc()
        {
            //社交+8体质+12虚荣+5 知识-6才华-2天份-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 12);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -6);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, -2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser03C
    {
        public static string desc = "参加辅导班";

        public static void ClickFunc()
        {
            //社交+3知识+12天份+8勤奋+3 体质-5虚荣-5
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 12);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -5);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser03D
    {
        public static string desc = "看漫画";

        public static void ClickFunc()
        {
            //才华+12知识+8勤奋+3幸运+2 体质-5社交-5
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 12);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -5);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser03E
    {
        public static string desc = "干饭";

        public static void ClickFunc()
        {
            //上五条+5 下三条-3
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -3);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser03F
    {
        public static string desc = "好好学习";

        public static void ClickFunc()
        {
            //知识+15天份+5勤奋+5 虚荣-5社交-5
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 15);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -5);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    #endregion
    #region 高中
    //+30 -15
    public class CreatUser04A
    {
        public static string desc = "谈恋爱";

        public static void ClickFunc()
        {
            //社交+15虚荣+7幸运+8 知识-7勤奋-8
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 15);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 7);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 8);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -7);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, -8);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser04B
    {
        public static string desc = "课外兼职";

        public static void ClickFunc()
        {
            //社交+9幸运+3体质+9勤奋+9 虚荣-7知识-7才华-1
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -7);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, -1);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -7);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser04C
    {
        public static string desc = "体育特长";

        public static void ClickFunc()
        {
            //社交+1体质+20勤奋+9 知识-10才华-3天份-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 1);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 20);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser04D
    {
        public static string desc = "艺术特长";

        public static void ClickFunc()
        {
            //社交+1才华+20勤奋+9 体质-10知识-3天份-2
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 1);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 20);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -3);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, -2);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser04E
    {
        public static string desc = "网吧战神";

        public static void ClickFunc()
        {
            //社交+10幸运+11勤奋+9 体质-2知识-10天份-2才华-1
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 11);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 9);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, -10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, -2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, -1);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    public class CreatUser04F
    {
        public static string desc = "备战高考";

        public static void ClickFunc()
        {
            //知识+10天份+10勤奋+10 体质-2社交-5虚荣-8
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 10);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -2);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -5);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -8);
            EventCenter.Dispatcher(EventType.CreateUserNextStory);
        }
    }
    #endregion
    #endregion

    #region 选择天赋

    public class Talent01
    {
        public static string desc = "<color=#4FE94C>我是谁???</color>";
        public static int quality = 4;
        public static bool used = false;
        
        public static string title = "全属性+20虚荣-20";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //全+20虚荣-20
            PlayerManager.Instance.ChangeAllData(20);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -40);
            used = true;
        }
    }
    public class Talent02
    {
        public static string desc = "<color=#EFC32A>独孤求败</color>";
        public static int quality = 1;
        public static bool used = false;

        public static string title = "体质拉满 社交-25";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //体质拉满 社交-25
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 1000);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -25);
            used = true;
        }
    }
    public class Talent03
    {
        public static string desc = "<color=#EFC32A>爱因斯坦</color>";
        public static int quality = 1;
        public static bool used = false;

        public static string title = "天份+30知识+30勤奋+30 体质-30社交-30";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //天份+30知识+30勤奋+30 体质-30社交-30
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, 30);
            PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 30);
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 30);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, -30);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -30);
            used = true;
        }
    }
    public class Talent04
    {
        public static string desc = "<color=#EFC32A>勤能补拙</color>";
        public static int quality = 1;
        public static bool used = false;

        public static string title = "勤奋拉满体质+20 虚荣-20才华-20天份-50";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //勤奋拉满体质+20 虚荣-20才华-20天份-50
            PlayerManager.Instance.ChangeData(PlayerDataType.Diligence, 1000);
            PlayerManager.Instance.ChangeData(PlayerDataType.Constitution, 20);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -20);
            PlayerManager.Instance.ChangeData(PlayerDataType.Talent, -50);
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, -20);
            used = true;
        }
    }
    public class Talent05
    {
        public static string desc = "<color=#EFC32A>社交名流</color>";
        public static int quality = 1;
        public static bool used = false;

        public static string title = "社交拉满 虚荣拉满";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //社交拉满 虚荣拉满
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, 1000);
            PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, 1000);
            used = true;
        }
    }
    public class Talent06
    {
        public static string desc = "<color=#EFC32A>才大气粗</color>";
        public static int quality = 1;
        public static bool used = false;

        public static string title = "才华拉满 社交-20";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //才华拉满 社交-20
            PlayerManager.Instance.ChangeData(PlayerDataType.Artistic, 1000);
            PlayerManager.Instance.ChangeData(PlayerDataType.Social, -20);
            used = true;
        }
    }
    public class Talent07
    {
        public static string desc = "<color=#EFC32A>四叶草</color>";
        public static int quality = 1;
        public static bool used = false;

        public static string title = "幸运拉满";
        public static void ClickFunc()
        {
            EventCenter.Dispatcher<UnityAction, string>(EventType.CreateUserNextTalent, ConfirmFunc, title);
        }

        public static void ConfirmFunc()
        {
            //幸运拉满
            PlayerManager.Instance.ChangeData(PlayerDataType.Luck, 1000);
            used = true;
        }
    }

    #endregion

    #region 宿舍选项
    public class StudyInRoom{
        public static string desc = "效率一般的学习，没有那么卷也没有那么高效";
        public static string useful = "精力-5 知识+3";
        public static string title = "宿舍自习";
        public static void ClickFunc(){
            List<string> list = new List<string>();
            list.Add(desc);
            list.Add(useful);
            EventCenter.Dispatcher<UnityAction, List<string>>(EventType.SelectUnityActionAndStringList, ConfirmFunc, list);
        }

        public static void ConfirmFunc(){
            if (CommonManager.CheckEnergyEnough(-5)){
                PlayerManager.Instance.ChangeData(PlayerDataType.Energy, -5);
                PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 3);
                UIManager.Instance.PushPanel<string>(UIPanelType.TipPopup, useful);
            }
        }
    }
    #endregion
    #region 商店选项
    public class ShopBuyNiceCloth{
        public static string desc = "买新衣服,这会使得你的虚荣心得到满足,但是现在还没添加钱这种道具,先扣你的精力吧";
        public static string useful = "精力-30 虚荣-30 魅力+10";
        public static string title = "买新衣服";
        public static void ClickFunc(){
            List<string> list = new List<string>();
            list.Add(desc);
            list.Add(useful);
            EventCenter.Dispatcher<UnityAction, List<string>>(EventType.SelectUnityActionAndStringList, ConfirmFunc, list);
        }

        public static void ConfirmFunc(){
            if (CommonManager.CheckEnergyEnough(-30)){
                PlayerManager.Instance.ChangeData(PlayerDataType.Energy, -30);
                PlayerManager.Instance.ChangeData(PlayerDataType.Vanity, -30);
                PlayerManager.Instance.ChangeData(PlayerDataType.Charm, 10);
                UIManager.Instance.PushPanel<string>(UIPanelType.TipPopup, useful);
            }
        }
    }
    #endregion
    #region 书架选项
    public class BookWatchNovel{
        public static string desc = "看小说,这使你疲劳但是快乐";
        public static string useful = "精力-20 心情+10";
        public static string title = "看小说";
        public static void ClickFunc(){
            List<string> list = new List<string>();
            list.Add(desc);
            list.Add(useful);
            EventCenter.Dispatcher<UnityAction, List<string>>(EventType.SelectUnityActionAndStringList, ConfirmFunc, list);
        }

        public static void ConfirmFunc(){
            if (CommonManager.CheckEnergyEnough(-20)){
                PlayerManager.Instance.ChangeData(PlayerDataType.Energy, -20);
                PlayerManager.Instance.ChangeData(PlayerDataType.Mood, 10);
                UIManager.Instance.PushPanel<string>(UIPanelType.TipPopup, useful);
            }
        }
    }
    #endregion
    #region 书桌选项
    public class DeckSelfStudy{
        public static string desc = "自学,压力好大啊，好枯燥啊";
        public static string useful = "精力-20 心情-10 知识+20 压力+5";
        public static string title = "自学";
        public static void ClickFunc(){
            List<string> list = new List<string>();
            list.Add(desc);
            list.Add(useful);
            EventCenter.Dispatcher<UnityAction, List<string>>(EventType.SelectUnityActionAndStringList, ConfirmFunc, list);
        }

        public static void ConfirmFunc(){
            if (CommonManager.CheckEnergyEnough(-20)){
                PlayerManager.Instance.ChangeData(PlayerDataType.Energy, -20);
                PlayerManager.Instance.ChangeData(PlayerDataType.Mood, -10);
                PlayerManager.Instance.ChangeData(PlayerDataType.Knowledge, 20);
                PlayerManager.Instance.ChangeData(PlayerDataType.Pressure, 5);
                UIManager.Instance.PushPanel<string>(UIPanelType.TipPopup, useful);
            }
        }
    }
    #endregion
}
