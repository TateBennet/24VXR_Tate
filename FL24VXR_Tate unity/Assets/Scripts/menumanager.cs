using UnityEngine;

public class SpawnMenuController : MonoBehaviour
{
    public GameObject menuPanel; // Assign the menu Panel in the inspector
    public GameObject[] prefabs; // Array to hold prefab options

    private bool isMenuOpen = false;

    void Update()
    {
        // Check for button press (example: 'X' button on Oculus or 'B' on a keyboard)
        if (Input.GetKey(KeyCode.JoystickButton1)) // Replace with your VR button input
        {
            ToggleMenu();
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
            menuPanel.transform.position = playerTransform.position + playerTransform.forward * 0.5f; // Adjust distance
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
