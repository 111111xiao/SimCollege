using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    public static int GetLeftRound()
    {
        return MaxRound - currentRound;
    }

    public static void RoundPlus()
    {
        currentRound += 1;
        Debug.Log($"当前回合是{currentRound}");
        if (currentRound == MaxRound)
        {
            UIManager.Instance.PushPanel(UIPanelType.EndPanel);
        }
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
