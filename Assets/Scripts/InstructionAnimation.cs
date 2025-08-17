using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionAnimation : MonoBehaviour
{
    public Image instruction;

    private Coroutine instructionAnimationAlphaCoroutine;
    private IEnumerator InstructionAlphaAnimation()
    {
        for (float alpha = 1f; alpha > 0; alpha -= Time.deltaTime * 4f)
        {
            instruction.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        instruction.color = new Color(1f, 1f, 1f, 1f);
        instruction.gameObject.SetActive(false);

        instructionAnimationAlphaCoroutine = null;
    }

    public void StartInstructionAlphaAnimation()
    {
        if (instructionAnimationAlphaCoroutine == null)
            instructionAnimationAlphaCoroutine = StartCoroutine(InstructionAlphaAnimation());
    }

    public void StopInstructionAlphaAnimation()
    {
        if (instructionAnimationAlphaCoroutine != null)
        {
            StopCoroutine(instructionAnimationAlphaCoroutine);
            instructionAnimationAlphaCoroutine = null;
        }
    }
}
