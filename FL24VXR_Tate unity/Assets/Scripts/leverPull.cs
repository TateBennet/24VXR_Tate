using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverPull : MonoBehaviour
{
    
    public float activationThreshold = 30f; // Angle to activate
    public GameObject prefabToInstantiate; // The prefab to spawn
    public Transform spawnPoint; // The location to spawn the prefab

    // Call this method when the lever is interacted with (e.g., OnGrab or custom event)
    public void CheckLeverAngle()
    {
        float angle = transform.localEulerAngles.x;
        if (angle > 180) angle -= 360; // Normalize angle

        if (angle >= activationThreshold)
        {
            Instantiate(prefabToInstantiate, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
