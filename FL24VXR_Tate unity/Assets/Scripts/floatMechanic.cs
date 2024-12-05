using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class floatMechanic : MonoBehaviour
{
    public XRDirectInteractor leftHandInteractor; // Drag your left hand interactor here
    public XRDirectInteractor rightHandInteractor; // Drag your right hand interactor here
    public Rigidbody playerRigidbody; // Drag the Rigidbody attached to your character here
    public float floatForce = 5f; // Adjust this value to control upward speed
    public AudioSource windSFX;

    void Update()
    {
        bool isHoldingHeliumObject = IsHoldingHeliumObject();
        bool isAButtonPressed = Input.GetKey(KeyCode.JoystickButton0); // For legacy input
        // Replace this with Input System handling if you're using the new Input System

        if (isHoldingHeliumObject && isAButtonPressed)
        {
            FloatUpwards();
        }
    }

    bool IsHoldingHeliumObject()
    {
        // Check if the left hand is holding an object and if it has the tag "helium"
        if (leftHandInteractor.hasSelection && leftHandInteractor.firstInteractableSelected != null)
        {
            GameObject leftHandObject = leftHandInteractor.firstInteractableSelected.transform.gameObject;
            if (leftHandObject.CompareTag("helium"))
            {
                return true;
            }
        }

        // Check if the right hand is holding an object and if it has the tag "helium"
        if (rightHandInteractor.hasSelection && rightHandInteractor.firstInteractableSelected != null)
        {
            GameObject rightHandObject = rightHandInteractor.firstInteractableSelected.transform.gameObject;
            if (rightHandObject.CompareTag("helium"))
            {
                return true;
            }
        }

        return false; // No object with the "helium" tag is being held
    }

    void FloatUpwards()
    {
        playerRigidbody.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);

    }
}
