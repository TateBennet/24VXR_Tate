using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    [SerializeField] private Animator grudge = null;


    [SerializeField] private bool openTrigger = false;

    [SerializeField] private string chooseAnimation = "animationName";

    public AudioSource theEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                grudge.Play(chooseAnimation, 0, 0.0f);
                theEnd.Play();
                gameObject.SetActive(false);
            }

        }

    }
}
