using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector2 moveVector;
    private Rigidbody rb;
    private float moveSpeed = 5f, jumpForce = 5f;
    private bool running, quicksand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (quicksand) rb.velocity = transform.rotation * new Vector3(Mathf.Clamp(moveVector.x * moveSpeed, -1, 1), Mathf.Clamp(rb.velocity.y, -0.5f, 2), Mathf.Clamp(moveVector.y * moveSpeed, -1, 1));
        else rb.velocity = transform.rotation * new Vector3(moveVector.x * moveSpeed, rb.velocity.y, moveVector.y * moveSpeed);
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
        /*if (Physics.SphereCast(transform.position, .4f, new Vector3(0, -1f, 0), out RaycastHit a, 1f))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }*/
        if (quicksand)
        {
            foreach (Collider collider in Physics.OverlapCapsule(transform.position - new Vector3(0, 1, 0), transform.position + new Vector3(0, 1, 0), .5f))
            {
                if (collider.CompareTag("quicksand"))
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                    break;
                }
            }
        }

        else if (Physics.SphereCast(transform.position, .4f, new Vector3(0, -1f, 0), out RaycastHit a, 1f))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        quicksand = true;
    }

    private void OnTriggerExit(Collider other)
    {
        quicksand = false;
    }

}
