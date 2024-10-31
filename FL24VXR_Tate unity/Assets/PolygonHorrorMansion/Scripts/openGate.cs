using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTriggerOpen : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;
    [SerializeField] private Animator mydoor2 = null;

    [SerializeField] private bool openTrigger = false;

    [SerializeField] private string chooseAnimation = "animationName";
    [SerializeField] private string chooseAnimation2 = "animationName";

    public AudioSource playSound;
    public bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger & !hasPlayed)
            {
                mydoor.Play(chooseAnimation, 0, 0.0f);
                mydoor2.Play(chooseAnimation2, 0, 0.0f);
                playSound.Play();
                hasPlayed = true;  
            } else
            {
                return;
            }
        }

    }
}
