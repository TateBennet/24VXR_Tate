using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoStart : MonoBehaviour
{
    [SerializeField] private bool openTrigger = false;

    public AudioSource playSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                playSound.Play();
                gameObject.SetActive(false);
            }

        }

    }
}
