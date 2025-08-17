using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipesSpawnerDebugPanel : MonoBehaviour, IDebugPanel
{
    public Text infoText; //* Chứa Text hiển thị Debug, làm thêm nếu cần
    public PipesSpawner pipesSpawner; //* Class cần Debug

    public void UpdatePanel()
    {
        infoText.text = $"Top random: {pipesSpawner.getTopRandom()}\nBottom random: {pipesSpawner.getBottomRandom()}";
    }
}

