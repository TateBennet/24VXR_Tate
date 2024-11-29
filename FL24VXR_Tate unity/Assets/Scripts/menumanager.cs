using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMenuController : MonoBehaviour
{
    public GameObject menuPanel; // Assign the menu Panel in the inspector
    public GameObject[] prefabs; // Array to hold prefab options
    public TextMeshProUGUI heliumtext;
    public TextMeshProUGUI hydrogentext;
    public TextMeshProUGUI chlorinetext;
    public TextMeshProUGUI lithiumtext;
    public GameObject heliumButton;
    public GameObject chlorineButton;
    public GameObject hydrogenButton;
    public GameObject lithiumButton;
    public PopUp pops;

    private bool isMenuOpen = false;

    private void Start()
    {
        heliumtext.enabled = false;
        chlorinetext.enabled = false;
        chlorineButton.SetActive(false);
        heliumButton.SetActive(false);
        hydrogenButton.SetActive(false);
        hydrogentext.enabled = false;
        lithiumButton.SetActive(false);
        lithiumtext.enabled = false;
        
    }

    void Update()
    {
        // Check for button press (example: 'X' button on Oculus or 'B' on a keyboard)
        if (Input.GetKey(KeyCode.JoystickButton1)) // Replace with your VR button input
        {
            ToggleMenu();
        }

        if (pops.displayedObjects.ContainsKey("helium")){
            heliumtext.enabled=true;
            heliumButton.SetActive(true);
            
        }

        if (pops.displayedObjects.ContainsKey("chlorine"))
        {
            chlorinetext.enabled = true;
            chlorineButton.SetActive(true);
           
        }
        if (pops.displayedObjects.ContainsKey("hydrogen"))
        {
            hydrogentext.enabled = true;
            hydrogenButton.SetActive(true);

        }
        if (pops.displayedObjects.ContainsKey("lithium"))
        {
            lithiumtext.enabled = true;
            lithiumButton.SetActive(true);

        }
    }

    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);

        if (isMenuOpen)
        {
            // Place the menu in front of the player
            Transform playerTransform = Camera.main.transform; // For VR, usually main camera is the head
            menuPanel.transform.position = playerTransform.position + playerTransform.forward * 0.369f; // Adjust distance
            menuPanel.transform.rotation = Quaternion.LookRotation(playerTransform.forward); // Face the player
        }
    }

    // Call this method from Button UI's OnClick() event
    public void SpawnPrefab(int prefabIndex)
    {
        if (prefabIndex >= 0 && prefabIndex < prefabs.Length)
        {
            Transform playerTransform = Camera.main.transform;
            Instantiate(prefabs[prefabIndex], playerTransform.position + playerTransform.forward * 0.5f, Quaternion.identity);
        }
        ToggleMenu(); // Optionally close the menu after spawning
    }
}
