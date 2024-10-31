using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class TriggerSFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource playSound;
    bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            playSound.Play();
            hasPlayed = true;
        } else
        {
            return;
        }
    }
}

