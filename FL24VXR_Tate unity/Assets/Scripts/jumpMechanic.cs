using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpMechanic : MonoBehaviour
{
    public float jumpForce = 5f;  // Strength of the jump
    public LayerMask groundLayer;  // Layer assigned to ground objects
    public Transform groundCheck;  // Empty GameObject to check if on ground
    public float groundCheckRadius = 0.2f;  // Radius for ground detection

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump on input if grounded
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Reset vertical velocity before applying jump force
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        // Visualize ground check in the scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
