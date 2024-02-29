using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    private Camera cam;
    private Rigidbody rb;
    private float sensitivity = 10;
    private float mouseMovementX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(0, mouseMovementX * sensitivity * Time.fixedDeltaTime, 0);
    }

    private void OnMouse(InputValue value)
    {
        mouseMovementX = value.Get<Vector2>().x;
    }
}
