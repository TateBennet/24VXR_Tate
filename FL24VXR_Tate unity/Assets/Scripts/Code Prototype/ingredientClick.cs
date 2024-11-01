using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientClick : MonoBehaviour
{
    public ingMngr ingredientManager;  // Reference to the centralized manager
    public timer timer; // reference to timer

    // Detect clicks on this ingredient
    private void OnMouseDown()
    {
        // blocks input if timer ran out
        if (timer.isInputBlocked == true)
        {
            return;
        }
        // Notify the manager that this ingredient was clicked
        ingredientManager.OnIngredientClicked(gameObject);
    }
}
