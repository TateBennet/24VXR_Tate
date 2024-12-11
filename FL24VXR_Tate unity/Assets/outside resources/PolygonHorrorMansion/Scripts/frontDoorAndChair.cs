using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontDoorAndChair : MonoBehaviour
{
    [SerializeField] private Animator frontDoorL = null;
    [SerializeField] private Animator frontDoorR = null;
    [SerializeField] private Animator rockingChair = null;

    [SerializeField] private bool openTrigger = false;

    [SerializeField] private string chooseAnimation = "animationName";
    [SerializeField] private string chooseAnimation2 = "animationName";
    [SerializeField] private string chooseAnimation3 = "animationName";

    public AudioSource playSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                frontDoorL.Play(chooseAnimation, 0, 0.0f);
                frontDoorR.Play(chooseAnimation2, 0, 0.0f);
                rockingChair.Play(chooseAnimation3, 0, 0.0f);

                playSound.Play();
                gameObject.SetActive(false);
            }

        }

    }
}
