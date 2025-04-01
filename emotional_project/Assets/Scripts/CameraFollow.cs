using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position
    public float smoothSpeed = 0.125f; // Smooth speed factor for the camera movement

    void Start()
    {
        // Optionally, you can set an initial offset if not assigned in the inspector
        offset = new Vector3(0, 1, -10); // Set an offset as an example (1 unit above the player, 10 units back)
    }

    void LateUpdate()
    {
        // Calculate the desired position based on the player's position plus the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}