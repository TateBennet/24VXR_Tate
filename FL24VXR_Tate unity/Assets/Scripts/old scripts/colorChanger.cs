using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    public void ChangeColor()
    {
        Renderer rend = GetComponent<Renderer>();
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            rend.material.color = randomColor;
    }
}
