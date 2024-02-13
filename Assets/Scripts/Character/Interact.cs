using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private void OnInteract()
    {
        if (Physics.SphereCast(transform.position - transform.rotation * new Vector3(0, 0, 2f), 2f, transform.forward, out RaycastHit hit, 2f))
        {
            hit.collider.gameObject.GetComponent<Interactive>().Interact();
        }
    }
}
