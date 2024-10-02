using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Rendering;
using UnityEngine;

public class invis : MonoBehaviour
{
    Renderer m_Renderer;

    float speed = 1f;
    bool startMoving = false;

    void Update()
    {
        if (startMoving == true)
        {
            float y = Mathf.PingPong(Time.time * speed, 1) * 250 - 3;
            gameObject.transform.position = new Vector3(1231, 317 + y, -93);
        }

        Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        m_Renderer.material.color = lerpedColor;
    }

    void Start()
    {
        //Fetch the Renderer component of the GameObject
        m_Renderer = GetComponent<Renderer>();

    }

    //Run your mouse over the GameObject to change the Renderer's material color to black
    void OnMouseDown()
    {
        startMoving = true;
    }

    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.white;
    }
}
