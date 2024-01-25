using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float maxVerticalAngle = 90f;
    public float maxHorizontalAngle = 90f;

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        
        horizontalRotation += mouseX * rotationSpeed;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -maxHorizontalAngle, maxHorizontalAngle);

        
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }
}
