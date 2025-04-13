using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Speed of the character
    public float jumpForce = 5f;       // Force applied when the character jumps
    private Rigidbody2D rb;             // Reference to the Rigidbody2D component
    private Animator animator;          // Reference to the Animator component
    private bool isGrounded;            // Check if the character is on the ground

    public Transform groundCheck;       // Reference point to check if grounded
    public LayerMask groundLayer;       // Layer mask for ground detection
    public float groundCheckRadius = 0.1f; // Radius for ground checking

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        Move(); // Handle movement input
        Jump(); // Handle jumping
        UpdateAnimator(); // Update animator parameters based on state
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right Arrow)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Set horizontal velocity
    }

    private void Jump()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // If the player is grounded and presses the Spacebar, jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply the jump force
            animator.SetBool("isJumping", true); // Switch to jump animation
        }
    }

    private void UpdateAnimator()
    {
        // Update animator parameters based on states
        animator.SetBool("isJumping", !isGrounded); // Set to true if not grounded (i.e., jumping)
        animator.SetBool("isGrounded", isGrounded); // Set to true if grounded
    }
}