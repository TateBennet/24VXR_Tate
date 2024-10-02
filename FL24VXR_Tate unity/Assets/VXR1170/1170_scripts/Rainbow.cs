using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    Renderer m_Renderer;

    public GameObject target;

    bool startRotate = false;

    Color currentColor;
    Color targetColor;
    float interval;
    [SerializeField] float speed = 5f;

    void Update()
    {
        if(startRotate == true)
        {
            // Spin the object around the target at 20 degrees/second.
            transform.RotateAround(target.transform.position, Vector3.up, 100 * Time.deltaTime);
        }
        
    }

    void Start()
    {
        //Fetch the Renderer component of the GameObject
        m_Renderer = GetComponent<Renderer>();
        resetColor();

    }

    //Run your mouse over the GameObject to change the Renderer's material color to black

    void OnMouseOver()
    {
        if (interval >= 1)
        {
            resetColor();
        }
        Color lerpedColor = Color.Lerp(currentColor, targetColor, interval);
        m_Renderer.material.color = lerpedColor;
        interval += Time.deltaTime * speed;

    }

    void resetColor()
    {
        interval = 0;   
        float random1, random2, random3;
        random1 = Random.Range(0f, 1f);
        random2 = Random.Range(0f, 1f);
        random3 = Random.Range(0f, 1f);

        currentColor = m_Renderer.material.color;
        targetColor = new Color(random1, random2, random3, 1);
    }

    private void OnMouseDown()
    {
        startRotate = true;
    }

    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.white;
    }
}
