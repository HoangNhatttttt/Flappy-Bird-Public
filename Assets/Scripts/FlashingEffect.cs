using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingEffect : MonoBehaviour
{
    public Image flashingEffectPanel;

    public float flashInTime = 0.1f;
    public float flashOutTime = 0.1f;

    private void Awake()
    {
        flashingEffectPanel.gameObject.SetActive(false);
        flashingEffectPanel.color = new Color(1f, 1f, 1f, 0f);
    }

    private Coroutine flashingEffectCoroutine;
    public IEnumerator FlashingEffectAnimation()
    {
        // Fade In
        for (float t = 0; t < flashInTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / flashInTime);
            flashingEffectPanel.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // Fade Out
        for (float t = 0; t < flashOutTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / flashOutTime);
            flashingEffectPanel.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        
        flashingEffectPanel.gameObject.SetActive(false);
        flashingEffectCoroutine = null;
    }

    public void StartFlashingEffectAnimation()
    {
        if (flashingEffectCoroutine == null)
        {
            flashingEffectPanel.gameObject.SetActive(true);
            flashingEffectCoroutine = StartCoroutine(FlashingEffectAnimation());
        }
    }

    public void StopFlashingEffectAnimation()
    {
        if (flashingEffectCoroutine != null)
        {
            StopCoroutine(FlashingEffectAnimation());
            flashingEffectPanel.gameObject.SetActive(false);
            flashingEffectCoroutine = null;
        }
    }
}
