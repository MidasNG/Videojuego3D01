using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveVector;
    private bool running, quicksand;
    private float moveSpeed = 5f, jumpSpeed = 5f;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (running) moveSpeed = 10f;
        else moveSpeed = 5f;

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
        if ( !running)
        {
            anim.SetBool("run", true);
        }
        else anim.SetBool("run", false);

    }

    private void OnJump()
    {
        anim.SetBool("jump", true);
        if (quicksand)
        {
            foreach (Collider collider in Physics.OverlapCapsule(transform.position - new Vector3(0, 1, 0), transform.position + new Vector3(0, 1, 0), .5f))
            {
                if (collider.CompareTag("quicksand"))
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
                    break;
                }
            }
        }

        else if (Physics.SphereCast(transform.position, .4f, new Vector3(0, -1f, 0), out RaycastHit a, 1f))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("quicksand")) quicksand = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("quicksand")) quicksand = false;
    }

}
