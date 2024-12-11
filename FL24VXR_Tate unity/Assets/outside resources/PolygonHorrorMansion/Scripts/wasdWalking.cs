using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdWalking : MonoBehaviour
{
    private CharacterController characterController;

    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // defines the character controller in code
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // this will take the input of our keyboard
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // move character using key inputs
        // delta time is basically a difference in time and how much has passed since the last game loop
        characterController.Move(move * Time.deltaTime * Speed);
    }
}
