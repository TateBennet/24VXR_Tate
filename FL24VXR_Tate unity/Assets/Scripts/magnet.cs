using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class magnet : MonoBehaviour
{
    public Transform player;                 // Reference to the player's Transform
    public XRGrabInteractable magnetObject;  // Reference to the magnet XRGrabInteractable
    public Transform laserGunPivot;          // Laser gun's pivot point (rotation axis)
    public float rotationSpeed = 2.0f;       // Control how fast the laser follows the player

    private bool isHoldingMagnet = false;    // Track whether the player is holding the magnet

    void Update()
    {
        // Check if the player is holding the magnet
        isHoldingMagnet = magnetObject.isSelected;

        // If holding the magnet, rotate the laser gun towards the player
        if (isHoldingMagnet)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Calculate direction to the player, constrain only to the Y-axis
        Vector3 direction = player.position - laserGunPivot.position;
        direction.y = 0;  // Ignore vertical differences

        // Check if the direction is not zero to avoid errors
        if (direction != Vector3.zero)
        {
            // Get the current rotation of the gun
            Quaternion currentRotation = laserGunPivot.rotation;

            // Create the target rotation for only the Y-axis (ignoring X and Z axes)
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Apply only Y-axis rotation change (keeping existing X rotation)
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotation.eulerAngles.y, currentRotation.eulerAngles.z);

            // Smoothly rotate towards the player
            laserGunPivot.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    }
