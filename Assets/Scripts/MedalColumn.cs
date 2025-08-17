using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalColumn : MonoBehaviour
{
    public Image medalImage;
    public ScoreColumn scoreColumn;
    public Sprite[] medalSprites;
    private int score;

    public GameManager gameManager;

    public void ShowMedal(int index)
    {
        medalImage.sprite = medalSprites[index];
        medalImage.color = new Color(1f, 1f, 1f, 1f);

        gameManager.sparkSpawner.StartSpawningSpark();
    }

    public void HideMedal() {
        medalImage.color = new Color(1f, 1f, 1f, 0f);
    }

    public void ChooseMedal()
    {
        score = scoreColumn.GetScore();
        int medalIndex = score / 20;
        switch (medalIndex)
        {
            case 0:
                break;
            case 1:
                ShowMedal(0);
                break;
            case 2:
                ShowMedal(1);
                break;
            case 3:
                ShowMedal(2);
                break;
            default:
                ShowMedal(3);
                break;
        }
    }
}
