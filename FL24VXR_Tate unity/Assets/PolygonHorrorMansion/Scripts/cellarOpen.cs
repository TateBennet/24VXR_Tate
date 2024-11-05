using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellarOpen : MonoBehaviour
{
    [SerializeField] private Animator cellarDoorL = null;
    [SerializeField] private Animator cellarDoorR = null;
    [SerializeField] private Animator woodchipper = null;

    [SerializeField] private bool openTrigger = false;

    public Light flickerLight; // Reference to the Light component
    public float minIntensity = 0.1f;
    public float maxIntensity = 25f;
    public float flickerSpeed = 0.3f;

    [SerializeField] private string chooseAnimation = "animationName";
    [SerializeField] private string chooseAnimation2 = "animationName";
    [SerializeField] private string chooseAnimation3 = "animationName";

    public AudioSource playSound;
    public AudioSource playSound2;
    public AudioSource stopSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                stopSound.Stop(); //stop woodchipper sound

                woodchipper.enabled = false; //stop woodchipper animation

                playSound.Play(); //play lightning

                StartCoroutine(Flicker());

                cellarDoorL.Play(chooseAnimation2, 0, 0.0f);
                cellarDoorR.Play(chooseAnimation, 0, 0.0f);

                playSound2.Play(); //play door slam

                StartCoroutine(DeactivateAfterDelay(1.5f));
                
            }

        }

    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        flickerLight.intensity = 1.58f;
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
