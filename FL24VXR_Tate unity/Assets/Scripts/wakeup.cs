using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wakeup : MonoBehaviour
{
    public float fadeDuration = 3.0f;     // Duration of the fade-in effect
    public float initialDelay = 2.0f;     // Delay before the fade starts

    private Image blackOverlay;
    private float fadeProgress = 0.0f;
    private float delayTimer = 0.0f;
    private bool delayComplete = false;

    void Start()
    {
        blackOverlay = GetComponent<Image>();
        blackOverlay.color = new Color(0, 0, 0, 1);  // Start fully black
    }

    void Update()
    {
        if (!delayComplete)
        {
            // Count the initial delay
            delayTimer += Time.deltaTime;
            if (delayTimer >= initialDelay)
            {
                delayComplete = true;  // Start the fade after the delay
            }
        }
        else if (fadeProgress < 1.0f)
        {
            // Increment fade progress based on time
            fadeProgress += Time.deltaTime / fadeDuration;
            blackOverlay.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, fadeProgress));
        }
        else
        {
            // Ensure fully transparent and disable the overlay
            blackOverlay.color = new Color(0, 0, 0, 0);
            gameObject.SetActive(false);
        }
    }
}
