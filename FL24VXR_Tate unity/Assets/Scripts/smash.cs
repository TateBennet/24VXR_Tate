using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class smash : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign Prefab3 here
    public XRDirectInteractor leftHandInteractor; // Drag your left hand interactor here
    public XRDirectInteractor rightHandInteractor; // Drag your right hand interactor here
    public Transform playerHead;     // Assign the camera (e.g., XR Rig's "Main Camera") here
    public float spawnDistance = 0.1f; // Distance in front of the player to spawn the object

    private void Update()
    {
        //bool isHoldingHydrogenAndChlorine = IsHoldingHydrogenAndChlorine();
    }

    bool IsHoldingHydrogen()
    {
        // Check if the left hand is holding an object and if it has the tag "helium"
        if (leftHandInteractor.hasSelection && leftHandInteractor.firstInteractableSelected != null)
        {
            GameObject leftHandObject = leftHandInteractor.firstInteractableSelected.transform.gameObject;
            if (leftHandObject.CompareTag("helium") || leftHandObject.CompareTag("chlorine"))
            {
                return true;
            }
        }

        return false; // No object with the "helium" or "chlorine" tag is being held
    }

    bool IsHoldingChlorine()
    {
        // Check if the right hand is holding an object and if it has the tag "helium"
        if (rightHandInteractor.hasSelection && rightHandInteractor.firstInteractableSelected != null)
        {
            GameObject rightHandObject = rightHandInteractor.firstInteractableSelected.transform.gameObject;
            if (rightHandObject.CompareTag("helium") || rightHandObject.CompareTag("chlorine"))
            {
                return true;
            }
        }
        return false;
    }

    public void OnTriggerEnter(Collider other)
    {

        bool isHoldingHydrogen = IsHoldingHydrogen();
        bool isHoldingChlorine = IsHoldingChlorine();
        
        // Check if the colliding object is the main part of Prefab2
        if (isHoldingHydrogen && isHoldingChlorine)
        {
            // Destroy both prefabs
            Destroy(other.gameObject); // Destroy Prefab2
            Destroy(this.gameObject); // Destroy Prefab1's parent

            if (prefabToSpawn != null && playerHead != null)
            {
                // Calculate spawn position in front of the player
                Vector3 spawnPosition = playerHead.position + playerHead.forward * spawnDistance;
                Quaternion spawnRotation = Quaternion.identity; // Default rotation, adjust if needed

                // Instantiate the prefab
                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            }
        }
    }
}
