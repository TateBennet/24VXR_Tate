using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class laserRotateHead : MonoBehaviour
{
    public Transform player; // Assign this in the Inspector
    private Quaternion initialRotation; // Store the initial rotation offset
    public float xOffset = 0f; // Fine-tune X-axis offset
    public float yOffset = 0f; // Fine-tune Y-axis offset
    public XRDirectInteractor leftHandInteractor; // Drag your left hand interactor here
    public XRDirectInteractor rightHandInteractor;

    void Start()
    {
        // Capture the initial rotation at the start
        initialRotation = transform.rotation;
    }

    void Update()
    {
        bool isAButtonPressed = Input.GetKey(KeyCode.JoystickButton0);

        if (isAButtonPressed && IsHoldingIron())
        {
            // Calculate the direction to the player
            Vector3 direction = player.position - transform.position;

            // Calculate the rotation towards the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Apply the initial rotation and manual offsets
            lookRotation *= initialRotation * Quaternion.Euler(xOffset, 0, yOffset);

            // Smoothly rotate towards the player with the offset
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    bool IsHoldingIron()
    {
        // Check if the left hand is holding an object and if it has the tag "iron"
        if (leftHandInteractor.hasSelection && leftHandInteractor.firstInteractableSelected != null)
        {
            GameObject leftHandObject = leftHandInteractor.firstInteractableSelected.transform.gameObject;
            if (leftHandObject.CompareTag("iron"))
            {
                return true;
            }
        }

        // Check if the right hand is holding an object and if it has the tag "iron"
        if (rightHandInteractor.hasSelection && rightHandInteractor.firstInteractableSelected != null)
        {
            GameObject rightHandObject = rightHandInteractor.firstInteractableSelected.transform.gameObject;
            if (rightHandObject.CompareTag("iron"))
            {
                return true;
            }
        }

        return false; // No object with the "iron" tag is being held
    }
}
