using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public float animationSpeed = 10;

    public Image scoreBoard;
    private Coroutine animationCoroutine;
    public ScoreColumn scoreColumnAnimation;
    public MedalColumn medalColumn;
    public ScoreColumn scoreColumn;
    public Vector3 scoreBoardAppearPosition = new Vector3(0, 0, 0);


    private void Awake()
    {
        scoreBoard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Screen.height * 0.7f);
    }


    private IEnumerator PlayFlyingAnimation()
    {
        medalColumn.HideMedal();
        scoreColumnAnimation.ResetScoreText();

        yield return new WaitForSeconds(0.5f);
        while (scoreBoard.GetComponent<RectTransform>().anchoredPosition.y < scoreBoardAppearPosition.y - 1)
        {
            ScorePanelFlyingAnimation();
            yield return null;
        }

        scoreColumnAnimation.StartScoreAnimationCoroutine();

        while (scoreColumnAnimation.IsScoreAnimationFinished() == false)
            yield return null;

        yield return new WaitForSeconds(0.1f);

        medalColumn.ChooseMedal();


        animationCoroutine = null;
    }

    public void StartFlyingAnimation()
    {
        if (animationCoroutine == null)
            animationCoroutine = StartCoroutine(PlayFlyingAnimation());
    }

    public void StopFlyingAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
        ResetScorePanelPosition();
    }

    private void ScorePanelFlyingAnimation()
    {
        Vector3 currentPosition = scoreBoard.GetComponent<RectTransform>().anchoredPosition;
        Vector3 targetPosition = scoreBoardAppearPosition; 
        scoreBoard.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * animationSpeed);
    }


    private void ResetScorePanelPosition()
    {
        scoreBoard.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -Screen.height * 0.7f, 0);
    }

}

