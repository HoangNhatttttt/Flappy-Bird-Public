using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColumn : MonoBehaviour
{
    public Text onagameScorePoints;
    public Text scoreText;
    public Text highscoreText;
    public GameManager gameManager;

    private Coroutine scoreAnimationCoroutine;
    public Image newHighscoreImage;

    private int score;
    private int highscore;
    public int externalPoints = 0;
    public float scoreIncreaseSpeed = 5f;

    public void Awake()
    {
        highscore = gameManager.gameSaveManager.LoadHighScore();
    }

    public void Start()
    {
        highscoreText.text = highscore.ToString();
    }

    public int GetScore()
    {
        int scorePoints = int.Parse(onagameScorePoints.text) + externalPoints;
        return scorePoints;
    }

    private bool scoreAnimationFinished;
    private IEnumerator ScoreAnimation()
    {
        score = GetScore();

        float tempScore = 0;
        float tempHighcore = (float)highscore;
        float speed = 0f;

        while (tempScore < score)
        {
            speed += Time.deltaTime * scoreIncreaseSpeed;
            tempScore += speed;

            if (tempScore > score)
                tempScore = score;

            if (tempHighcore < tempScore)
                tempHighcore = tempScore;

            scoreText.text = ((int)tempScore).ToString();
            highscoreText.text = ((int)tempHighcore).ToString();

            yield return null;
        }
        scoreAnimationFinished = true;

        if (highscore < score)
        {
            newHighscoreImage.gameObject.SetActive(true);
            highscore = score;
            gameManager.gameSaveManager.SaveHighScore(highscore);
        }

        scoreAnimationCoroutine = null;
    }

    public bool IsScoreAnimationFinished()
    {
        return scoreAnimationFinished;
    }

    public void ResetScoreText()
    {
        scoreText.text = "0";
    }

    public void StartScoreAnimationCoroutine()
    {
        scoreAnimationFinished = false;
        if (scoreAnimationCoroutine == null)
            scoreAnimationCoroutine = StartCoroutine(ScoreAnimation());
    }

    public void StopScoreAnimationCoroutine()
    {
        if (scoreAnimationCoroutine != null)
        {
            StopCoroutine(scoreAnimationCoroutine);
            scoreAnimationCoroutine = null;
            scoreAnimationFinished = true;
        }
    }

    public void ResetHighScore()
    {
        highscore = 0;
        highscoreText.text = "0";
    }
}