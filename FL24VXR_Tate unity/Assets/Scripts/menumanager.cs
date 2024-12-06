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
    public GameObject heliumButton;
    public GameObject chlorineButton;
    public GameObject hydrogenButton;
    public GameObject lithiumButton;
    public GameObject ironButton;
    public PopUp pops;
    public coins coins;
    public TextMeshProUGUI coinsText;

    private bool isMenuOpen = false;

    private void Start()
    {
        chlorineButton.SetActive(false);
        heliumButton.SetActive(false);
        hydrogenButton.SetActive(false);
        lithiumButton.SetActive(false);
        ironButton.SetActive(false);
        UpdateCoinDisplay();
        
    }

    void Update()
    {

        // Check for button press (example: 'X' button on Oculus or 'B' on a keyboard)
        if (Input.GetKeyDown(KeyCode.JoystickButton1)) // Replace with your VR button input
        {
            ToggleMenu();
        }

        if (pops.displayedObjects.ContainsKey("helium")){
            heliumButton.SetActive(true);
            
        }

        if (pops.displayedObjects.ContainsKey("chlorine"))
        {
            chlorineButton.SetActive(true);
           
        }
        if (pops.displayedObjects.ContainsKey("hydrogen"))
        {
            hydrogenButton.SetActive(true);

        }
        if (pops.displayedObjects.ContainsKey("lithium"))
        {
            lithiumButton.SetActive(true);

        }
        if (pops.displayedObjects.ContainsKey("iron"))
        {
            ironButton.SetActive(true);

        }

        UpdateCoinDisplay();    

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

    void UpdateCoinDisplay()
    {
        // Get the total coin count from the CoinTracker script
        int totalCoins = coins.coinCount;

        // Update the text UI to show the current coin count
        coinsText.text = totalCoins.ToString() + "/100 collected";
    }
}
