using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakLock : MonoBehaviour
{
    [SerializeField] GameObject myLock;
    [SerializeField] GameObject brokenLock;
    [SerializeField] private Animator door1 = null;
    [SerializeField] private string chooseAnimation1 = "animationName";
    [SerializeField] private Animator door2 = null;
    [SerializeField] private string chooseAnimation2 = "animationName";

    private void OnTriggerEnter(Collider other)
    {
        //if laser collides with lock play animation
        if (other.gameObject.CompareTag("laserbeam"))
        {
            openDoors();

        }

        [ContextMenu("open")]

        void openDoors()
        {
            //swap the intact lock for the broken lock and open the doors
            Debug.Log("collision detected");
            myLock.SetActive(false);
            brokenLock.SetActive(true);
            door1.Play(chooseAnimation1, 0, 0.0f);
            door2.Play(chooseAnimation2, 0, 0.0f);
            Debug.Log("animations played");
        }
    }
}
