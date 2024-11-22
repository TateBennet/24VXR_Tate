using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button nextButton;

    // Array of dialogue lines
    public string[] dialogueLines;
    private int currentLineIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextLine);
        DisplayNextLine();
    }

    void DisplayNextLine()
    {
        // Only proceed if we are not currently typing
        if (isTyping)
            return;

        if (currentLineIndex < dialogueLines.Length)
        {
            StartCoroutine(TypeSentence(dialogueLines[currentLineIndex]));
            currentLineIndex++;
        }
        else
        {
            // Dialogue finished; hide button or trigger other events
            dialogueText.text = "";
            nextButton.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = ""; // Clear previous text
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust typing speed here
        }
        isTyping = false;
    }
}
