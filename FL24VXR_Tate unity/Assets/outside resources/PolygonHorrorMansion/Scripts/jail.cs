using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jail : MonoBehaviour
{
    [SerializeField] private Animator jailDoor1 = null;
    [SerializeField] private Animator jailDoor2 = null;
    [SerializeField] private Animator jailDoor3 = null;
    [SerializeField] private Animator maskRise = null;
    [SerializeField] private Animator light = null;

    [SerializeField] private GameObject demie = null;
    [SerializeField] private GameObject ghoulie = null;
    [SerializeField] private GameObject butchie = null;
    [SerializeField] private GameObject grudge = null;
    [SerializeField] private GameObject jumpscare = null;

    [SerializeField] private bool openTrigger = false;

    public Light flickerLight; // Reference to the Light component
    public float minIntensity = 0.1f;
    public float maxIntensity = 10f;
    public float flickerSpeed = 0.3f;

    [SerializeField] private string chooseAnimation = "animationName";
    [SerializeField] private string chooseAnimation2 = "animationName";
    [SerializeField] private string chooseAnimation3 = "animationName";
    [SerializeField] private string chooseAnimation4 = "animationName";
    [SerializeField] private string chooseAnimation5 = "animationName";

    public AudioSource demon;
    public AudioSource slam;
    public AudioSource stopSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                stopSound.Stop(); //stop baby crying

                StartCoroutine(Flicker());

                demon.Play(); //play whisper

                maskRise.Play(chooseAnimation4, 0, 0.0f);
                light.Play(chooseAnimation5, 0, 0.0f);

                StartCoroutine(DeactivateAfterDelay(3f));

            }

        }

    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        slam.Play();
        jailDoor1.Play(chooseAnimation3, 0, 0.0f);
        jailDoor2.Play(chooseAnimation2, 0, 0.0f);
        jailDoor3.Play(chooseAnimation, 0, 0.0f);

        flickerLight.intensity = 0;

        demie.SetActive(true);
        ghoulie.SetActive(true);
        butchie.SetActive(true);
        grudge.SetActive(true);
        jumpscare.SetActive(true);

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

