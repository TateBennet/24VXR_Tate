using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    Renderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

        //Run your mouse over the GameObject to change the Renderer's material color to black
        void OnMouseOver()
    {
        m_Renderer.material.color = Color.yellow;
        transform.localScale += new Vector3(0, 0, 0.1f);
    }


    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.white;
    }
}
