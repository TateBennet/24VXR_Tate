using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic; // For Dictionary

public class PopUp : MonoBehaviour
{
    public GameObject popupCanvas;             // Assign your Canvas object in the Inspector
    private CanvasGroup canvasGroup;           // For fading effect
    public TextMeshProUGUI popupText;          // Reference to the TextMeshPro text element
    public float fadeDuration = 1f;            // Time for fade-in/out
    public float displayDuration = 3f;         // Visible duration
    public Dictionary<string, bool> displayedObjects = new Dictionary<string, bool>();  // Track shown objects

    void Start()
    {
        canvasGroup = popupCanvas.GetComponent<CanvasGroup>();
        popupCanvas.SetActive(false);           // Ensure the pop-up is hidden at the start
    }

    public void ShowPopup(string message, string objectTag)
    {
        if (!displayedObjects.ContainsKey(objectTag) || !displayedObjects[objectTag])
        {
            displayedObjects[objectTag] = true;  // Mark this object as displayed
            popupText.text = message;            // Set the dynamic text
            popupCanvas.SetActive(true);
            StartCoroutine(FadePopup());
        }
    }

    IEnumerator FadePopup()
    {
        float timer = 0f;

        // Fade In
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            yield return null;
        }

        // Wait for the display duration
        yield return new WaitForSeconds(displayDuration);

        // Fade Out
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            yield return null;
        }

        popupCanvas.SetActive(false);           // Hide the pop-up
    }
}
