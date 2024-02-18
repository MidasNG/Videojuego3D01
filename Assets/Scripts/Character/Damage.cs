using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int health = 4;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && collision.rigidbody.CompareTag("hazard"))
        {
            health--;
        }
    }
}
