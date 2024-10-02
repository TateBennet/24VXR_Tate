using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour
{
    Renderer m_Renderer;

    //Assign a GameObject in the Inspector to rotate around

    void Start()
    {
        //Fetch the Renderer component of the GameObject
        m_Renderer = GetComponent<Renderer>();

    }

    //Run your mouse over the GameObject to change the Renderer's material color to black
    void OnMouseOver()
    {
        m_Renderer.material.color = Color.magenta;
    }

    private void OnMouseDown()
    {
        float H, S, V;

        Color.RGBToHSV(new Color(0.9f, 0.7f, 0.1f, 1.0F), out H, out S, out V);
        Debug.Log("H: " + H + " S: " + S + " V: " + V);
    }

    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.white;
    }
}
