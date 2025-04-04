using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the character
    public float jumpForce = 5f; // Force applied when the character jumps

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded; // Check if the character is on the ground

    public Transform groundCheck; // Reference point to check if grounded
    public LayerMask groundLayer; // Layer mask for ground detection

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        Move(); // Call Move method for player movement
        Jump(); // Call Jump method for player jump
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Use Unity's built-in Horizontal axis
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Set the horizontal velocity
    }

    private void Jump()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // If the player is grounded and presses the Spacebar, jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply the jump force
        }
    }
}