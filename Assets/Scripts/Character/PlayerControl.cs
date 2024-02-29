using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    private Vector2 moveVector;
    [SerializeField] private Rigidbody rb;
    private float moveSpeed = 5f, jumpSpeed = 5f;
    [SerializeField] private AudioSource clipSource;
    private bool sprinting, quicksand, jumping, freeze;

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

        else if (Physics.SphereCast(transform.position - new Vector3(0, .5f, 0), .4f, Vector3.down, out RaycastHit hitInfo, .6f) && hitInfo.normal != Vector3.up && !jumping) rb.velocity = transform.rotation * new Vector3(moveVector.x * moveSpeed, Mathf.Clamp(rb.velocity.y, -100, .5f), moveVector.y * moveSpeed);

        else if (rb.useGravity == false) rb.velocity = Vector3.zero;

        else rb.velocity = transform.rotation * new Vector3(moveVector.x * moveSpeed, rb.velocity.y, moveVector.y * moveSpeed);

        if (anim != null && moveVector.magnitude != 0 && clipSource != null)
        {
            if (!clipSource.isPlaying)
            {
                clipSource.Play();
            }

            if (sprinting)
            {
                anim.SetBool("run", false);
                anim.SetBool("sprint", true);
                clipSource.pitch = 1;
            }
            else if (clipSource != null)
            {
                anim.SetBool("run", true);
                anim.SetBool("sprint", false);
                clipSource.pitch = 0.7f;
            }
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("sprint", false);
            clipSource.Stop();
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
            jumping = true;
            if (anim != null) anim.SetTrigger("jump");
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("quicksand")) quicksand = true;

        else if (other.CompareTag("loadmaps")) other.GetComponent<LoadMaps>()?.LoadUnload();

        else if (other.CompareTag("activatingTrigger"))
        {
            other.GetComponent<CloseDoor>()?.Activate();
            other.GetComponent<DeleteTreasure>()?.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("quicksand")) quicksand = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.SphereCast(transform.position - new Vector3(0, .5f, 0), .4f, Vector3.down, out RaycastHit hitInfo, .6f)) jumping = false;
        if (freeze) rb.useGravity = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (freeze) rb.useGravity = false;
        else rb.useGravity = true;
    }

    public void DialogueFreeze(bool value)
    {
        freeze = value;
    }
}
