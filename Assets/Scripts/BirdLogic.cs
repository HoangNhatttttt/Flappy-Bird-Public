using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdLogic : MonoBehaviour
{
    public GameManager gameManager;

    public BirdAnimation birdAnimation;

    public float jumpStrength = 7f;
    public float maxDownSpeed = -10f;
    public float defaultGravityScale = 2f;

    public bool isHitSFXPlayed = false;
    public bool enableUserInput = true;
    public bool isCrashed = false;

    public float flapCooldown = 0.1f;

    private Rigidbody2D birdRigidbody2D;

    private void Awake()
    {
        birdAnimation = GetComponent<BirdAnimation>();
        birdRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void setBirdGravity(bool value)
    {
        if (value)
            birdRigidbody2D.gravityScale = defaultGravityScale;
        else
            birdRigidbody2D.gravityScale = 0f;
    }

    public void resetBirdVelocity()
    {
        birdRigidbody2D.velocity = Vector2.zero;
    }

    private Coroutine flapBirdCooldownCroutine;

    private IEnumerator FlapBirdCooldown()
    {
        FlapBird();
        yield return new WaitForSeconds(flapCooldown);

        flapBirdCooldownCroutine = null;
    }

    public void StartFlapBirdCooldown()
    {
        if (flapBirdCooldownCroutine == null)
            flapBirdCooldownCroutine = StartCoroutine(FlapBirdCooldown());
    }

    public void StopFlapBirdCooldown()
    {
        if (flapBirdCooldownCroutine != null)
        {
            StopCoroutine(flapBirdCooldownCroutine);
            flapBirdCooldownCroutine = null;
        }
    }

    public void FlapBird()
    {
        birdRigidbody2D.velocity = new Vector2(0f, jumpStrength);
        gameManager.soundManager.PlayFlap();
        birdAnimation.StartRotateUpAnimation();
    }


    private void Update()
    {
        // Nhấn chuột trái hoặc space bar để nhảy
        if (enableUserInput == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                StartFlapBirdCooldown();
            else if (Input.GetMouseButtonDown(0))
                if (!EventSystem.current.IsPointerOverGameObject())
                    StartFlapBirdCooldown();
        }

        if (isCrashed == false)
            ClampVelocity();

        if (enableUserInput)
            birdAnimation.RotateAnimation();
    }

    public void ClampVelocity()
    {
        Vector2 velocity = birdRigidbody2D.velocity;
        velocity.y = Mathf.Clamp(velocity.y, maxDownSpeed, jumpStrength);
        birdRigidbody2D.velocity = velocity;
    }


    public void ResetPosition()
    {
        Vector3 startPosition = transform.position;
        startPosition.y = 0f;
        this.transform.position = startPosition;
    }

    private void OnEnable()
    { }

    private IEnumerator DelayDieSFX(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.soundManager.PlayDie();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Pipes" || other.tag == "Ground") && isCrashed == false)
        {
            isCrashed = true;
            gameManager.gameOverManager.GameOver();

            if (isHitSFXPlayed == false)
            {
                isHitSFXPlayed = true;

                gameManager.soundManager.PlayHit();
                StartCoroutine(DelayDieSFX(0.15f));
                
            }
        }

        else if (other.tag == "Scoring")
        {
            FindAnyObjectByType<GameManager>().AddScore(1);
            gameManager.soundManager.PlayScore();
        }

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            birdAnimation.StopRotateCoroutine();
        }
    }

    public float getYVelocity()
    {
        return birdRigidbody2D.velocity.y;
    }
}
