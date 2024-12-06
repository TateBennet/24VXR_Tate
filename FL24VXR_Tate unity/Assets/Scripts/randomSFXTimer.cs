using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSFXTimer : MonoBehaviour
{
    public AudioSource audioSource; // Assign your AudioSource here
    private float timer;
    private float nextPlayTime;

    void Start()
    {
        SetRandomInterval();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextPlayTime)
        {
            PlaySound();
            SetRandomInterval();
        }
    }

    void SetRandomInterval()
    {
        timer = 0;
        nextPlayTime = Random.Range(10f, 30f); // Random time between 10 and 30 seconds
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the sound attached to the AudioSource
            Debug.Log("buzzzzz");
        }
    }
}