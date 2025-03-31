using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;           // Speed of the character
    public float jumpHeight = 2f;          // Height of the jump
    public float gravity = -9.81f;          // Gravity value (negative for downward force)
    public Transform groundCheck;           // Transform to check if character is grounded
    public float groundDistance = 0.1f;     // Distance for ground checking
    public LayerMask groundMask;            // LayerMask to define what is considered ground

    private CharacterController characterController;
    private Vector3 velocity;               // Current velocity of the character
    private bool isGrounded;                // Indicates if the character is on the ground

    private void Start()
    {
        // Get the CharacterController component attached to the character
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keep the character on the ground
        }

        // Get input from the Horizontal and Vertical axis
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

        // Create a movement vector based on input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the character
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Jumping mechanic
        if (isGrounded && Input.GetButtonDown("Jump")) // Spacebar (default for Jump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the character based on the velocity
        characterController.Move(velocity * Time.deltaTime);

        // Optional: Rotate the character towards the movement direction
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
    }
}