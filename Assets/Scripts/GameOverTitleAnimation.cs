using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverTitleAnimation : MonoBehaviour
{
    public float alphaSpeed = 1f;
    public Image gameOverTitle;
    private Animator animator;

    private void Awake()
    {
        animator = gameOverTitle.GetComponent<Animator>();
    }

    public void PlayGameOverAnimation()
    {
        animator.SetTrigger("playGameOverTitleAnimation");
        StartGameOverTitleAlpha();
    }

    private Coroutine gameOverTitleAlphaCoroutine;
    private IEnumerator GameOverTitleAlpha()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * alphaSpeed;
            gameOverTitle.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        gameOverTitleAlphaCoroutine = null;
    }

    public void StartGameOverTitleAlpha()
    {
        if (gameOverTitleAlphaCoroutine == null)
            gameOverTitleAlphaCoroutine = StartCoroutine(GameOverTitleAlpha());
    }

    public void StopGameOverTitleAlpha()
    {
        if (gameOverTitleAlphaCoroutine != null)
        {
            StopCoroutine(gameOverTitleAlphaCoroutine);
            gameOverTitleAlphaCoroutine = null;
        }
    }
}
