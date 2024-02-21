using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveVector;
    private bool sprinting, quicksand;
    private float moveSpeed = 5f, jumpSpeed = 5f;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (sprinting) moveSpeed = 10f;
        else moveSpeed = 5f;

        if (quicksand) rb.velocity = transform.rotation * new Vector3(Mathf.Clamp(moveVector.x * moveSpeed, -1, 1), Mathf.Clamp(rb.velocity.y, -0.5f, 2), Mathf.Clamp(moveVector.y * moveSpeed, -1, 1));
        else rb.velocity = transform.rotation * new Vector3(moveVector.x * moveSpeed, rb.velocity.y, moveVector.y * moveSpeed);

        if(anim != null && moveVector.magnitude != 0) 
        {
            if (sprinting)
            {
                anim.SetBool("run", false);
                anim.SetBool("sprint", true);
            }
            else
            {
                anim.SetBool("run", true);
                anim.SetBool("sprint", false);
            }
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("sprint", false);
        }

        if (transform.position.y < -40) 
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    private void OnMovement(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }

    private void OnRun()
    {
        sprinting = !sprinting;
    }

    private void OnJump()
    {
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

        else if (Physics.SphereCast(transform.position + new Vector3(0, .5f, 0), .4f, new Vector3(0, -1f, 0), out RaycastHit a, .5f))
        {
            if (anim != null) anim.SetTrigger("jump");
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
        
    }

    private void OnExit()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
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
