using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // The target the camera will follow
    public Vector3 offset;        // Offset from the target
    public float smoothSpeed = 0.125f; // Speed of the camera movement

    private void LateUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Optional: Make camera look at the target
        transform.LookAt(target);
    }
}