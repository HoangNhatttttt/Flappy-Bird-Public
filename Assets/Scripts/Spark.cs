using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spark : MonoBehaviour
{
    public Sprite[] sparkSprites;
    public Image sparkImage;

    public float sparkAnimationSpeed = 0.05f;

    private int spriteIndex = 0;

    private void Start()
    {
        StartSparkAnimation();
    }

    private void SparkAnimation()
    {
        spriteIndex++;

        if (spriteIndex >= sparkSprites.Length)
        {
            Destroy(this.gameObject);
            return;
        }
            

        sparkImage.sprite = sparkSprites[spriteIndex];
    }

    public void StartSparkAnimation()
    {
        InvokeRepeating(nameof(SparkAnimation), sparkAnimationSpeed, sparkAnimationSpeed);
    }

    
}
