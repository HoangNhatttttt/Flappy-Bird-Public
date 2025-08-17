using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public GameManager gameManager;

    public void FreezeBirdCenter()
    {
        gameManager.birdAnimation.gameObject.SetActive(true);

        gameManager.birdAnimation.StopRotateCoroutine();
        gameManager.birdAnimation.ResetTiltTimer();

        gameManager.birdLogic.enableUserInput = false;
        gameManager.birdLogic.setBirdGravity(false);
        gameManager.birdLogic.resetBirdVelocity();
        gameManager.birdLogic.ResetPosition();
    }
     
    public void Idle()
    {
        
        gameManager.gameUIManager.playButton.gameObject.SetActive(false);
        gameManager.gameUIManager.menuTitle.gameObject.SetActive(false);

        gameManager.gameUIManager.pauseResumeButton.gameObject.SetActive(true);
        gameManager.gameUIManager.ButtonPauseImage();
        gameManager.gameUIManager.onGameScoreText.gameObject.SetActive(true);
        gameManager.gameUIManager.budgetTouchScreen.gameObject.SetActive(true);
        gameManager.gameUIManager.instructionAnimation.gameObject.SetActive(true);
        
        gameManager.birdAnimation.enableRotating = false;
        gameManager.birdAnimation.StartFlyingAnimation();
        gameManager.birdAnimation.ResetRotation();
        
        gameManager.gameUIManager.background.enableMoving = true;
        gameManager.gameUIManager.ground.enableMoving = true;
    }

    public void Play()
    {
        gameManager.birdAnimation.enableRotating = true;

        gameManager.birdLogic.enableUserInput = true;
        gameManager.birdLogic.setBirdGravity(true);

        gameManager.pipesSpawner.StartSpawningPipes();
    }

    public void Restart()
    {   
        gameManager.soundManager.PlayTransition();
        gameManager.gameUIManager.transitionEffect.StartTransitionEffectAnimation(() =>
        {

            FreezeBirdCenter();

            gameManager.pipesSpawner.DestroyPipes();

            gameManager.sparkSpawner.StopSpawningSpark();
            gameManager.sparkSpawner.DestroySpark();
            
            gameManager.gameOverManager.restartButton.gameObject.SetActive(false);
            gameManager.gameOverManager.resetHighscoreButton.gameObject.SetActive(false);
            gameManager.gameOverManager.gameOverTitle.gameObject.SetActive(false);
            gameManager.gameUIManager.scoreBoard.scoreColumn.newHighscoreImage.gameObject.SetActive(false);
            gameManager.gameUIManager.scoreBoard.StopFlyingAnimation();

            gameManager.birdLogic.isHitSFXPlayed = false;
            gameManager.birdLogic.isCrashed = false;  

            gameManager.scorePoint = 0;
            gameManager.AddScore(0); // Mỗi lần AddScore sẽ cập nhật lại số điểm trên màn hình --> gọi hàm để reset điểm về 0

            Idle();
        });
    }

    public void Menu()
    {
        gameManager.birdLogic.gameObject.SetActive(false);

        gameManager.gameOverManager.resetHighscoreButton.gameObject.SetActive(false);
        gameManager.gameUIManager.pauseResumeButton.gameObject.SetActive(false);
        gameManager.gameUIManager.instructionAnimation.gameObject.SetActive(false);
        gameManager.gameUIManager.budgetTouchScreen.gameObject.SetActive(false);
        gameManager.gameOverManager.restartButton.gameObject.SetActive(false);
        gameManager.gameUIManager.onGameScoreText.gameObject.SetActive(false);
    }

    public void Pause()
    {
        if (gameManager.birdLogic.isCrashed)
            return;
        
        Time.timeScale = 0f;
        gameManager.birdLogic.enabled = false;
        gameManager.gameUIManager.ButtonResumeImage();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameManager.birdLogic.enabled = true;
        gameManager.gameUIManager.ButtonPauseImage();
    }
}