using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //access textmeshpro ui elements

public class RecipeGenerator : MonoBehaviour
{
    public List<GameObject> allObjects;   // List of the 5 ingredients
    public Transform spawnParent;         // The parent object where selected objects will be instantiated (the pan)
    public Vector3 spawnOffset = new Vector3(2, 0, 0);  // Offset between spawned objects
    public GameObject buttonObject;       // The gameobject acting as the button (the pan)
    public ingMngr ingredientManager;  // Reference to the centralized manager

    private List<GameObject> currentSelectedObjects = new List<GameObject>(); //Track currently selected objects for the recipe
    public timer timer; //refernece to my timer

    public TextMeshProUGUI scoreText; // UI Text field to display the score
    private int score = 0;

    void Start()
    {
        SelectRandomObjects(); //creates my recipe upon game start
    }

    // This method will be called when the "button" object is clicked (the pan)
    private void OnMouseDown()
    {
        //essentially exits the function early to prevent input if the timer is zero
        if (timer.isInputBlocked == true)
        {
            return;
        }

        // Check if the clicked object is the "button" then compares the recipe to chosen ingredients, clears the pan and generates a new recipe resetting the pan count as well.
        if (gameObject == buttonObject)
        {
            Debug.Log("Button object clicked!");
            CompareIngredientLists();
            ClearPreviousSelection();
            SelectRandomObjects();
            ingredientManager.ClearPan();
            ingredientManager.ingredientCount = 0;
        }
        else
        {
            Debug.Log("Clicked on something else.");
        }
    }

    // Select 3 random objects from the ingredient list and instantiates them
    void SelectRandomObjects()
    {
        for (int i = 0; i < 3; i++)
        {
            //choose random index and use it to pick an ingredient from the list
            int randomIndex = Random.Range(0, allObjects.Count);
            GameObject selectedObject = allObjects[randomIndex];

            // Instantiate the selected object with a position offset for each
            Vector3 spawnPosition = spawnParent.position + (spawnOffset * i);
            GameObject newObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity, spawnParent);

            // Add the object to the currently selected list
            currentSelectedObjects.Add(newObject);
        }
    }

    // Clear previous recipe
    void ClearPreviousSelection()
    {
        foreach (GameObject obj in currentSelectedObjects)
        {
            Destroy(obj);
        }
        currentSelectedObjects.Clear();
    }

    void CompareIngredientLists()
    {
        // Compare each element in both lists using item names and array count
        bool allMatch = true; // Assume all elements match until proven otherwise
        for (int i = 0; i < currentSelectedObjects.Count; i++)
        {
            if (currentSelectedObjects[i].name != ingredientManager.panIngredients[i].name)
            {
                allMatch = false;
                break; // Exit loop as soon as a mismatch is found
            }
        }

        // Output result
        if (allMatch)
        {
            AddPoints(10);
        }
    }

    // Method to add points to the score
    void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update the score on the UI text field
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Earnings: $" + score.ToString();
        }
    }
}
