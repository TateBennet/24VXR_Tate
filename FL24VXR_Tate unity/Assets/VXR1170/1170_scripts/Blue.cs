using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
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
        m_Renderer.material.color = Color.blue;
    }

    private void OnMouseDown()
    {
        int x = Random.Range(50, 1400);
        int y = Random.Range(0, 600);
        transform.position = new Vector3(x, y, -93);
      
    }

    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.blue;
    }
}
