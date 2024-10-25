using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingMngr : MonoBehaviour
{
    public Transform plateTransform;              // The Transform of the "plate" GameObject
    public Vector3 plateOffset = new Vector3(0.5f, 0, 0);  // Offset for spacing on X-axis only
    public float fixedHeight = 0.5f;              // Fixed Y-axis position for all ingredients
    public Vector3 ingredientScale = new Vector3(2f, 2f, 2f);  // Scale factor for ingredients
    public float leftOffset = -0.5f;              // Overall offset to move all ingredients further left
    public int ingredientCount = 0;              // Track how many ingredients have been added
    public int maxIngredients = 3;                // Maximum number of ingredients allowed

    public List<GameObject> panIngredients = new List<GameObject>(); //ingredients in the pan

    // This method will be called by each ingredient when clicked
    public void OnIngredientClicked(GameObject ingredient)
    {
   
        // Check if the maximum number of ingredients has been reached
        if (ingredientCount >= maxIngredients)
        {
            Debug.Log("Maximum number of ingredients reached!");
            return; // Exit the method without adding more ingredients
        }

        // Calculate the position for the new ingredient
        Vector3 newIngredientPosition = plateTransform.position + (plateOffset * ingredientCount);

        // Apply the left offset to all ingredients
        newIngredientPosition.x += leftOffset; // Move all ingredients further left

        // Set a fixed height for the Y-axis (ignoring multiplication)
        newIngredientPosition.y = plateTransform.position.y + fixedHeight;

        // Instantiate the clicked ingredient at the new position
        GameObject newIngredient = Instantiate(ingredient, newIngredientPosition, Quaternion.identity);

        // Scale the new ingredient to make it larger
        newIngredient.transform.localScale = ingredientScale;

        panIngredients.Add(newIngredient);

        // Increment the count for the next ingredient to be placed beside this one
        ingredientCount++;
        Debug.Log(panIngredients);
    }

    // destroy the objects in the pan and clear it for the next recipe
    public void ClearPan()
    {

        foreach (GameObject obj in panIngredients)
        {
            Destroy(obj);
        }
        panIngredients.Clear();
    }
}
