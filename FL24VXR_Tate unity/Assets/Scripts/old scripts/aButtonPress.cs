using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aButtonPress : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0)) // Adjust button index if necessary
        {
            Debug.Log("A Button Pressed!");
            // Add your logic here
        }
    }
}
