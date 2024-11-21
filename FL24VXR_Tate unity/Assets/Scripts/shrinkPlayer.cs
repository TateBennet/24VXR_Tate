using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f); // Target size for 2-3 inches
    [SerializeField] private float characterScale = 0.1f;

    void Start()
    {
        // Set the rig's scale immediately when the game starts
        transform.localScale = targetScale;
        Physics.gravity = Physics.gravity * characterScale;
    }
}
