using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdRotationDebugPanel : MonoBehaviour, IDebugPanel
{
    public Text infoText; //* Chứa Text hiển thị Debug, làm thêm nếu cần
    public BirdAnimation birdAnimation; //* Class cần Debug

    public void UpdatePanel()
    {
        infoText.text = $"Angle: {birdAnimation.getCurrentAngle()}";
    }
}

