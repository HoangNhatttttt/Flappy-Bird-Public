using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{

    private Coroutine rotateCoroutine;

    public BirdLogic birdLogic;

    public float rotateUpSpeed = 150f;
    public float rotateDownSpeed = 150f;
    public float rotateUpAngle = 30f;
    public float rotateDownAngle = -90f;

    private float currentAngle = 0f;
    private float targetAngle = 0f;
    public float targetRotateSpeed = 0f;

    public bool enableRotating = false;
    public float tiltUpDuration = 0.5f;
    private float tiltTimer = 0f;

    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    private int spriteIndex = 0;
    public float animationSpeed = 0.15f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private float tempRotateDownAngle;

    private void OnEnable()
    {
        tempRotateDownAngle = rotateDownAngle;
    }

    public void RotateAnimation()
    {
        if (enableRotating == false)
            return;
        if (tiltTimer > 0)
        {
            tiltTimer -= Time.deltaTime;

            targetAngle = rotateUpAngle;
            targetRotateSpeed = rotateUpSpeed;
        }

        else
        {
            targetAngle = rotateDownAngle;
            targetRotateSpeed = rotateDownSpeed;
        }

        currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, targetRotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }

    public void ResetRotation()
    {
        currentAngle = 0;
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void StartRotateUpAnimation()
    {
        tiltTimer = tiltUpDuration;
    }

    public void ResetTiltTimer()
    {
        tiltTimer = 0;
    }

    public void FlyingAnimation()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
            spriteIndex = 0;

        spriteRenderer.sprite = sprites[spriteIndex];
    }


    public void StartFlyingAnimation()
    {
        InvokeRepeating(nameof(FlyingAnimation), animationSpeed, animationSpeed);
    }

    private IEnumerator FallingRotateBeakDown()
    {
        rotateDownAngle = -90f;
        while (currentAngle >= -90f)
        {
            RotateAnimation();
            yield return null;
        }
    }

   
    public void StartRotateCoroutine()
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
            rotateCoroutine = StartCoroutine(FallingRotateBeakDown());
        }

        else
            rotateCoroutine = StartCoroutine(FallingRotateBeakDown());
    }

    public void StopRotateCoroutine()
    {
        rotateDownAngle = tempRotateDownAngle;

        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
            rotateCoroutine = null;
        }
    }

    public void StopFlyingAnimation()
    {
        CancelInvoke(nameof(FlyingAnimation));
    }

    public float getCurrentAngle()
    {
        return currentAngle;
    }
}
