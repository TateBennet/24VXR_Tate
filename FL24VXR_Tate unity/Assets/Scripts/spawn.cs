using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject objectToInstantiate;

    // Position for the spawn point, entered as x, y, z in the Inspector
    public Vector3 spawnPoint;

    // Method called when the button is clicked
    public void OnButtonClick()
    {
        // Instantiate the object at the specified spawn point position
        Instantiate(objectToInstantiate, spawnPoint, Quaternion.identity);
    }
}
