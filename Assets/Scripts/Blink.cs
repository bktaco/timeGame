using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blinkTime;
    public SpriteRenderer leftEye;
    public Sprite EyeImage;
    public Sprite EyeBlinked;
    public SpriteRenderer rightEye;
    private float blinkTimeCounter;

    private void FixedUpdate()
    {
        if (blinkTimeCounter > 0)
        {
            blinkTimeCounter -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(BlinkCo());
            blinkTimeCounter = blinkTime;
        }

    }

    private IEnumerator BlinkCo()
    {
        leftEye.sprite = EyeBlinked;
        rightEye.sprite = EyeBlinked;
        yield return new WaitForSeconds(.1f);
        leftEye.sprite = EyeImage;
        rightEye.sprite = EyeImage;
    }
}
