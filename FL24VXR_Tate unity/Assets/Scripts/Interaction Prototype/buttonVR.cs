using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class buttonVR : MonoBehaviour
{

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    public GameObject helium;
    bool isPressed;
    public AudioSource diskTraySFX;

    [SerializeField] private Animator diskTray = null;

    [SerializeField] private string chooseAnimation = "animationName";

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed) {
            button.transform.localPosition = new Vector3(0, 0, -0.003f);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0, -0.006f);
            onRelease.Invoke();
            isPressed=false;
        }
    }

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localPosition = new Vector3(3.76f, 0.758f, 0.616f);
        sphere.transform.localScale = new Vector3(0.345f, 0.345f, 0.345f);
        sphere.AddComponent<Rigidbody>();
        sphere.AddComponent<XRGrabInteractable>();

    }

    public void playSound()
    {
        diskTraySFX.Play();
    }

    public void diskTrayFunction()
    {
        diskTray.Play(chooseAnimation, 0, 0.0f);
        StartCoroutine(ActivateAfterSeconds(3f));
    }

    IEnumerator ActivateAfterSeconds(float delay)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        // Activate the GameObject
        helium.SetActive(true);
    }

}
