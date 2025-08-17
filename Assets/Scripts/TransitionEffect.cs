using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionEffect : MonoBehaviour
{
    public Image transitionEffectPanel;

    public float transitionInTime = 0.25f;
    public float transitionOutTime = 0.25f;

    private void Awake()
    {
        transitionEffectPanel.gameObject.SetActive(false);
        transitionEffectPanel.color = new Color(0f, 0f, 0f, 0f);
    }

    private Coroutine transitionEffectCoroutine;

    public IEnumerator TransitionEffectAnimation(System.Action onFadeInComplete)
    {
        // Fade In
        for (float t = 0; t < transitionInTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / transitionInTime);
            transitionEffectPanel.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        onFadeInComplete?.Invoke();
        // Fade Out        
        for (float t = 0; t < transitionOutTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / transitionOutTime);
            transitionEffectPanel.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        transitionEffectPanel.gameObject.SetActive(false);
        transitionEffectCoroutine = null;
    }


    public void StartTransitionEffectAnimation(System.Action onFadeInComplete = null)
    {
        if (transitionEffectCoroutine == null)
        {
            transitionEffectPanel.gameObject.SetActive(true);
            transitionEffectCoroutine = StartCoroutine(TransitionEffectAnimation(onFadeInComplete));
        }
    }

    public void StopTransitionEffectAnimation()
    {
        if (transitionEffectCoroutine != null)
        {
            StopCoroutine(transitionEffectCoroutine);
            transitionEffectPanel.gameObject.SetActive(false);
            transitionEffectCoroutine = null;
        }
    }

}
