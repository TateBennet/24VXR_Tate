using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoStop : MonoBehaviour
{
    [SerializeField] private Animator pianoDoor = null;

    [SerializeField] private bool openTrigger = false;

    [SerializeField] private string chooseAnimation = "animationName";

    public AudioSource playSound;
    public AudioSource playSound2;
    public AudioSource playSound3;
    public AudioSource stopSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                stopSound.Stop();
                playSound.Play();
                playSound2.Play();
                playSound3.Play();
                pianoDoor.Play(chooseAnimation, 0, 0.0f);
                gameObject.SetActive(false); 

            }

        }

    }

}
