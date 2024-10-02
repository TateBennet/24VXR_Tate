using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    Renderer m_Renderer;

    void Start()
    {
        //Fetch the Renderer component of the GameObject
        m_Renderer = GetComponent<Renderer>();

    }

    //Run your mouse over the GameObject to change the Renderer's material color to black
    void OnMouseOver()
    {
        Color orange = new Color(1f, 0.6f, 0,1);
        m_Renderer.material.color = orange;
        transform.position = transform.position + new Vector3(0, 0.33f, 0);
    }

    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.white;
    }
}
