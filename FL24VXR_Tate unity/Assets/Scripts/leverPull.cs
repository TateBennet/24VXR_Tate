using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverPull : MonoBehaviour
{
    
    public float activationThreshold = 30f; // Angle to activate
    public GameObject prefabToInstantiate; // The prefab to spawn
    public Transform spawnPoint; // The location to spawn the prefab
    public AudioSource pop;
    public GameObject hydrogen;
    private bool hasplayed = false;

    // Call this method when the lever is interacted with (e.g., OnGrab or custom event)
    public void CheckLeverAngle()
    {
        float angle = transform.localEulerAngles.x;
        if (angle > 180) angle -= 360; // Normalize angle

        if (angle >= activationThreshold) // pull lever at least 60 degrees
        {
            if (!hasplayed)
            {
                //instantiate first object and play sfx to ensure it carries proper sfx on prefab on first instance
                hydrogen.SetActive(true);
                pop.Play();
                hasplayed = true;
            }
            else if (hasplayed)
            {
                // instantiate prefab duplicates after the first and play sfx
                Instantiate(prefabToInstantiate, spawnPoint.position, spawnPoint.rotation);
                pop.Play();
            }
        }
    }

}
