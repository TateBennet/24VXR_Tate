using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCombiner : MonoBehaviour
{
    public Transform rightHand; // Reference to the right hand Transform
    public Transform leftHand;  // Reference to the left hand Transform
    public GameObject newObjectPrefab; // Prefab for the combined object

    private GameObject rightHandObject = null; // Object in the right hand
    private GameObject leftHandObject = null;  // Object in the left hand

    void Update()
    {
        // Check if both hands are holding objects
        if (rightHandObject != null && leftHandObject != null)
        {
            // Check for collision between objects
            if (AreObjectsColliding(rightHandObject, leftHandObject))
            {
                CombineObjects();
            }
        }
    }

    private bool AreObjectsColliding(GameObject obj1, GameObject obj2)
    {
        // Use colliders to detect collision
        Collider col1 = obj1.GetComponent<Collider>();
        Collider col2 = obj2.GetComponent<Collider>();

        if (col1 != null && col2 != null)
        {
            return col1.bounds.Intersects(col2.bounds);
        }

        return false;
    }

    private void CombineObjects()
    {
        // Destroy the current objects
        Destroy(rightHandObject);
        Destroy(leftHandObject);

        // Spawn the new combined object in the right hand
        GameObject newObject = Instantiate(newObjectPrefab, rightHand.position, rightHand.rotation);

        // Assign the new object to the right hand
        rightHandObject = newObject;

        // Clear the left hand
        leftHandObject = null;
    }

    public void BassignObjectToHand(bool isRightHand)
    {
        if (isRightHand)
        {
            rightHandObject = null;
        }
        else
        {
            leftHandObject = null;
        }
    }

    public void ReleaseObjectFromHand(bool isRightHand)
    {
        if (isRightHand)
        {
            rightHandObject = null;
        }
        else
        {
            leftHandObject = null;
        }
    }
}
