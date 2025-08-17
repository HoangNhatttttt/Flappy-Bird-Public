using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameManager gameManager;

    public Button budgetTouchScreen;
    public Button pauseResumeButton;
    public Button playButton;

    public Sprite[] pauseResumeButtonSprites;

    public Text onGameScoreText;

    public Background background;
    public Background ground;

    public Image menuTitle;

    public MenuTitleAnimation menuTitleAnimation;
    public TransitionEffect transitionEffect;
    public FlashingEffect flashingEffect;
    
    public InstructionAnimation instructionAnimation;

    public GameOverManager gameOverManager;
    public GameOverTitleAnimation gameOverTitleAnimation;
    
    public ScoreBoard scoreBoard;
    public ScoreColumn scoreColumn;
    public MedalColumn medalColumn;
    
    private void Start()
    {
        gameOverTitleAnimation.gameOverTitle.color = new Color(1f, 1f, 1f, 0f);
        scoreBoard.scoreColumn.newHighscoreImage.gameObject.SetActive(false);
    }

    public void ButtonPauseImage()
    {
        pauseResumeButton.GetComponent<Image>().sprite = pauseResumeButtonSprites[0];
    }

    public void ButtonResumeImage()
    {
        pauseResumeButton.GetComponent<Image>().sprite = pauseResumeButtonSprites[1];
    }

    public void PauseAndResume()
    {
        gameManager.soundManager.PlayTransition();

        gameManager.birdLogic.enableUserInput = false;

        if (pauseResumeButton.GetComponent<Image>().sprite == pauseResumeButtonSprites[0])
        {
            ButtonResumeImage();
            gameManager.gameStateManager.Pause();
        }

        else if (pauseResumeButton.GetComponent<Image>().sprite == pauseResumeButtonSprites[1])
        {
            ButtonPauseImage();
            gameManager.gameStateManager.Resume();
        }

        gameManager.birdLogic.enableUserInput = true;
    }

    public void PlayButton() //! Fix Rotate
    {
        gameManager.soundManager.PlayTransition();
        transitionEffect.StartTransitionEffectAnimation(() =>
        {
            gameManager.gameStateManager.FreezeBirdCenter();
            gameManager.gameStateManager.Idle();
        });

    }

    public void BudgetTouchScreen()
    {
        gameManager.gameUIManager.budgetTouchScreen.gameObject.SetActive(false);
        instructionAnimation.StartInstructionAlphaAnimation();
        gameManager.gameStateManager.Play();
        gameManager.birdLogic.StartFlapBirdCooldown();  
    }             
}