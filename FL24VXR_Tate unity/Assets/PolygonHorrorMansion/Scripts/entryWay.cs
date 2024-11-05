using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class entryWay : MonoBehaviour
{
    [SerializeField] private Animator entrywayL = null;
    [SerializeField] private Animator entrywayR = null;
    [SerializeField] private Animator hallwayR = null;
    [SerializeField] private Animator hallwayL = null;
    [SerializeField] private Animator chanda = null;

    [SerializeField] private bool openTrigger = false;

    public Light flickerLight; // Reference to the Light component
    public float minIntensity = 0.1f;
    public float maxIntensity = 50f;
    public float flickerSpeed = 0.3f;

    [SerializeField] private string chooseAnimation = "animationName";
    [SerializeField] private string chooseAnimation2 = "animationName";
    [SerializeField] private string chooseAnimation3 = "animationName";
    [SerializeField] private string chooseAnimation4 = "animationName";
    [SerializeField] private string chooseAnimation5 = "animationName";

    public AudioSource playSound;
    public AudioSource playSound2;
    public AudioSource playSound3;
    public AudioSource playSound4;

    public ContinuousMoveProviderBase moveProvider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger && !playSound.isPlaying)
            {
                moveProvider.enabled = false;
                playSound.Play();
                StartCoroutine(DeactivateAfterDelay(2.0f));
                StartCoroutine(Flicker());
                StartCoroutine(chandaCrash(playSound4, 5.2f));// Adjust delay as needed
                StartCoroutine(StopSoundAfterDelay(playSound,6.0f));// Adjust delay as needed

            }

        }
        
    }
    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        entrywayL.Play(chooseAnimation, 0, 0.0f);
        entrywayR.Play(chooseAnimation2, 0, 0.0f);
        chanda.Play(chooseAnimation3, 0, 0.0f);
        hallwayR.Play(chooseAnimation4, 0, 0.0f);
        hallwayL.Play(chooseAnimation5, 0, 0.0f);

        playSound2.Play();
        playSound3.Play();
    }

    private IEnumerator chandaCrash(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }

    private IEnumerator StopSoundAfterDelay(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
        moveProvider.enabled = true;
        flickerLight.intensity = 0;
        gameObject.SetActive(false);
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}

