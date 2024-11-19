using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hoopScorer : MonoBehaviour
{
    public int score = 0;                  // Player's current score
    public int pointsPerBasket = 2;       // Points for each basket
    public TextMeshProUGUI scoreboardText; // Optional: Assign your scoreboard UI here

    private void OnTriggerEnter(Collider other)
    {
        // Add points when anything enters the trigger
        AddPoints(pointsPerBasket);
    }

    private void AddPoints(int points)
    {
        score += points; // Increment score
        Debug.Log("Score: " + score);

        // Update the scoreboard UI if it exists
        if (scoreboardText != null)
        {
            scoreboardText.text = "Score: " + score;
        }
    }
}
