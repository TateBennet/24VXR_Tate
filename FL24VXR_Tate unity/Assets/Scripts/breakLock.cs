using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakLock : MonoBehaviour
{
    [SerializeField] GameObject myLock;
    [SerializeField] GameObject brokenLock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("laserbeam"))
        {
            Debug.Log("collision detected");
            myLock.SetActive(false);
            brokenLock.SetActive(true);
        }
    }
}
