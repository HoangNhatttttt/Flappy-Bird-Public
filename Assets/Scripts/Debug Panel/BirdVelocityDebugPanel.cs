using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdVelocityDebugPanel : MonoBehaviour, IDebugPanel
{
    public Text infoText; //* Chứa Text hiển thị Debug, làm thêm nếu cần
    public BirdLogic birdLogic; //* Class cần Debug

    public void UpdatePanel()
    {
        infoText.text = $"Y velocity: {birdLogic.getYVelocity()}";
    }
}

