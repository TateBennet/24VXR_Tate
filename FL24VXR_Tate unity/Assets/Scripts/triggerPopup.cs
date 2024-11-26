using UnityEngine;

public class TriggerPopup : MonoBehaviour
{
    public string displayMessage;            // Custom message for this object
    private PopUp popupManager;        // Reference to the main script

    void Start()
    {
        popupManager = FindObjectOfType<PopUp>();  // Find the pop-up manager in the scene
    }

    public void OnSelectEnter()              // Called when the object is grabbed
    {
        popupManager.ShowPopup(displayMessage, gameObject.tag);
    }
}
