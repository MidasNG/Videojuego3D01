using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector2 moveVector;
    private Rigidbody rb;
    private float moveSpeed = 5f, jumpForce = 5f;
    private bool running;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.rotation * new Vector3(moveVector.x * moveSpeed, rb.velocity.y, moveVector.y * moveSpeed);
    }

    private void OnMovement(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }

    private void OnRun()
    {
        running = !running;
    }

    private void OnJump()
    {
        if (Physics.Raycast(transform.position, new Vector3(0, -1f, 0), 1.1f))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }      
    }
}
