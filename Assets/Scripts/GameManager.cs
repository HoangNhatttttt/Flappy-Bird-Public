using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameUIManager gameUIManager;
    public GameOverManager gameOverManager;
    public GameStateManager gameStateManager;
    public GameSaveManager gameSaveManager;

    public BirdAnimation birdAnimation;
    public BirdLogic birdLogic;

    public PipesSpawner pipesSpawner;
    public SparkSpawner sparkSpawner;

    public SoundManager soundManager;


    public int scorePoint = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(800, 500, false);
    }

    public void AddScore(int points)
    {
        scorePoint += points;
        gameUIManager.onGameScoreText.text = scorePoint.ToString();
    }

    private void Start()
    {
        gameStateManager.Menu();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale != 0f && gameUIManager.playButton.gameObject.activeSelf == false)
            gameStateManager.Pause();

        else if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 0f)
            gameStateManager.Resume();
    }
}