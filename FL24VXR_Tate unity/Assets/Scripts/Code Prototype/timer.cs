using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] float remainingTime; //field to adjust the remaining time
    public bool isInputBlocked = false; //check to disable things after timer reaches zero

    // Update is called once per frame
    void Update()
    {
        //simple check to run the remaining time down if it is above zero or block user input once time runs out
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0; //keeps clock from running into negative
            isInputBlocked = true; //sets input block variable
            gameOver.gameObject.SetActive(true); //displays game over text
        }

        //calcuklates remaining time and updates it onscreen
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = ("Time: " + seconds);

    }
}
