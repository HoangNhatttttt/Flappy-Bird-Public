using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameManager gameManager;

    private Coroutine gameOverCoroutine;

    public GameOverTitleAnimation gameOverTitleAnimation;
    public Button resetHighscoreButton;
    public Button restartButton;
    public Image gameOverTitle;

    public void GameOver()
    {
        gameManager.gameUIManager.budgetTouchScreen.gameObject.SetActive(false);
        gameManager.birdLogic.enableUserInput = false;
        StartFalling();

        gameManager.gameUIManager.onGameScoreText.gameObject.SetActive(false);
        gameManager.gameUIManager.pauseResumeButton.gameObject.SetActive(false);

        gameManager.gameUIManager.flashingEffect.StartFlashingEffectAnimation();

        gameManager.gameUIManager.ground.enableMoving = false;
        gameManager.gameUIManager.background.enableMoving = false;

        gameManager.pipesSpawner.StopSpawningPipes();
        gameManager.pipesSpawner.StopPipesMoving();

        StartGameOverCoroutine();
    }

    public void StartFalling()
    {
        gameManager.birdAnimation.StopFlyingAnimation();
        gameManager.birdAnimation.StartRotateCoroutine();
    }

    private void StartGameOverCoroutine()
    {
        if (gameOverCoroutine == null)
            gameOverCoroutine = StartCoroutine(GameOverCoroutine());
    }


    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(0.35f);

        gameOverTitle.gameObject.SetActive(true);
        gameOverTitleAnimation.PlayGameOverAnimation();

        gameManager.gameUIManager.scoreBoard.StartFlyingAnimation();

        yield return new WaitForSeconds(1.2f);

        restartButton.gameObject.SetActive(true);
        resetHighscoreButton.gameObject.SetActive(true);

        gameOverCoroutine = null;
    }

    public void ResetHighscoreButton()
    {
        gameManager.gameSaveManager.SaveHighScore(0);
        gameManager.gameUIManager.scoreBoard.scoreColumn.ResetHighScore();
    }
}