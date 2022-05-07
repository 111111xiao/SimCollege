using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    private static int MaxRound = 48;
    // 当前回合数可能需要存档
    private static int currentRound = 1;

    public static int CurrentRound
    {
        get => currentRound;
        set => currentRound = value;
    }

    public void ResetData()
    {
        currentRound = 1;
        PlayerManager.Instance.Init();
    }

    public static int GetLeftRound()
    {
        return MaxRound - currentRound;
    }

    public static void RoundPlus()
    {
        currentRound += 1;        
        Debug.Log($"当前回合是{currentRound}");
        PlayerManager.Instance.ChangeData(PlayerDataType.Energy, 100);
        if (currentRound == MaxRound)
        {
            UIManager.Instance.PushPanel(UIPanelType.EndPanel);
            return;
        }
        if (currentRound >= 6 && currentRound % 6 == 0){
            //回家
            UIManager.Instance.PushPanel(UIPanelType.HomePanel);
            return;
        }
        if (currentRound >= 6 && currentRound % 6 == 2){
            // 返校
            UIManager.Instance.PushPanel(UIPanelType.CollegePanel);
            return;
        }

    }
    public void ExitGame()
    {
        //预处理
#if UNITY_EDITOR    //在编辑器模式下
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
