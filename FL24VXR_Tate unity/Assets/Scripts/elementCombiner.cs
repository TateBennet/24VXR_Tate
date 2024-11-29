using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class elementCombiner : MonoBehaviour
{
    public GameObject byproductPrefab; // Assign the new object prefab in the Inspector
    public Rigidbody rb;

    private bool isHeldL = false;
    private bool isHeldR = false;// Track if the object is held

    XRGrabInteractable grabInteractableL;
    XRGrabInteractable grabInteractableR;// Assign in the Inspector

    void Start()
    {
        grabInteractableL = GetComponent<XRGrabInteractable>();
        grabInteractableL.selectEntered.AddListener((args) => OnPickupL());
        grabInteractableL.selectExited.AddListener((args) => OnReleaseL());
        grabInteractableR = GetComponent<XRGrabInteractable>();
        grabInteractableR.selectEntered.AddListener((args) => OnPickupR());
        grabInteractableR.selectExited.AddListener((args) => OnReleaseR());
    }

    void Update()
    {
        // Ensure the Rigidbody is not set to kinematic
        if (rb != null && rb.isKinematic)
        {
            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Only proceed if this object is held
        if (isHeldL && isHeldR)
        {
            // Check the tags of both objects
            bool thisIsHelium = gameObject.CompareTag("hydrogen");
            bool thisIsChlorine = gameObject.CompareTag("chlorine");

            bool otherIsHelium = collision.gameObject.CompareTag("hydrogen");
            bool otherIsChlorine = collision.gameObject.CompareTag("chlorine");

            // Only mix if one is helium and the other is chlorine
            if ((thisIsHelium && otherIsChlorine) || (thisIsChlorine && otherIsHelium))
            {
                // Instantiate the byproduct at the collision point
                Instantiate(byproductPrefab, collision.contacts[0].point, Quaternion.identity);

                // Destroy both objects
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }

    // Method to call when the object is picked up
    public void OnPickupL()
    {
        isHeldL = true;

    }

    public void OnPickupR()
    {
        isHeldR = true;

    }

    // Method to call when the object is released
    public void OnReleaseL()
    {
        isHeldL = false;
    }

    public void OnReleaseR()
    {
        isHeldR = false;
    }
}
