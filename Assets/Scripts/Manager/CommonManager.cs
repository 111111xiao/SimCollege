using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonManager{

    public static string AddQualityColorByDataType(PlayerDataType type){
        float value = PlayerManager.Instance.GetData(type);
        string str = value.ToString();
        string redColor = $"<color=#EA4C4C>{str}</color>";
        string greenColor = $"<color=#4FE94C>{str}</color>";
        string yellowColor = $"<color=#E9CB4C>{str}</color>";
        if (value < 30){
            if (type == PlayerDataType.Pressure){
                return greenColor;
            }
            return redColor;
        }else if (value > 60){
            if (type == PlayerDataType.Pressure){
                return redColor;
            }
            return greenColor;
        }else{
            return yellowColor;
        }
    }

    public static bool CheckEnergyEnough(float value){
        float remain = PlayerManager.Instance.GetData(PlayerDataType.Energy) + value;
        if (remain < 0){
            UIManager.Instance.PushPanel<string>(UIPanelType.TipPopup, "精力不足!");
            return false;
        }
        return true;
    }
}
