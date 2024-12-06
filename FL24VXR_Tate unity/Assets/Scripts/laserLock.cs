using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class laserLock : MonoBehaviour
{
    public float pullSpeed = 0.5f;                // Speed to pull the object
    public Transform targetTransform;           // Reference to the target position (assign in Inspector or dynamically)
    public float scaleUpFactor = 1.5f;          // Factor by which to scale the object
    public float rotationSpeed = 0.5f;            // Speed for rotation matching
    public Material highlightColor;
    public GameObject laserBeam;
    bool hasplayed = false;
    public GameObject particles;

    private Rigidbody frozenRigidbody;

    public AudioSource laserSFX;

    [SerializeField] private Animator laserActivate = null;
    [SerializeField] private string chooseAnimation = "animationName";
    public float delayInSeconds = 7f;

    void OnTriggerEnter(Collider other)
    {

            laserSFX.Play();
            laserActivate.Play(chooseAnimation, 0, 0.0f);
            particles.SetActive(false);

            StartCoroutine(StopAnimationAfterDelay());
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && targetTransform != null) // Ensure there is a target
            {

                Renderer renderer = other.GetComponent<Renderer>();
                if (renderer != null)
                {
                    // Change the color to the highlight color
                    renderer.material = highlightColor;
                }

                // Check if the object is held and force release it
                var grabComponent = other.GetComponent<XRGrabInteractable>();
                if (grabComponent && grabComponent.isSelected)
                {
                    grabComponent.interactionManager.SelectExit(grabComponent.selectingInteractor, grabComponent);
                }
                StartCoroutine(PullAndRotateObject(rb, targetTransform.position, targetTransform.rotation, grabComponent));
            }

    }

    IEnumerator PullAndRotateObject(Rigidbody rb, Vector3 targetPosition, Quaternion targetRotation, XRGrabInteractable grabComponent)
    {
        while (Vector3.Distance(rb.position, targetPosition) > 0.001f)
        {
            // Move towards the target position
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, pullSpeed * Time.deltaTime));

            // Smoothly rotate towards the target rotation
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

            yield return null;
        }

        // Final adjustments
        rb.position = targetPosition;
        rb.rotation = targetRotation;

        // Scale up the object before freezing
        rb.transform.localScale *= scaleUpFactor;

        // Freeze position but allow rotation
        rb.constraints = RigidbodyConstraints.FreezePosition;

        if (grabComponent != null)
        {
            grabComponent.enabled = false;
        }

        // Store the rigidbody reference to rotate it in Update
        frozenRigidbody = rb;
    }

    IEnumerator StopAnimationAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delayInSeconds);
        laserBeam.SetActive(true);
    }

    void Update()
    {
        // Apply continuous rotation to the frozen object
        if (frozenRigidbody != null)
        {
            frozenRigidbody.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
