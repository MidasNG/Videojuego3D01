using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCylinder : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddTorque(360 * Time.deltaTime, 0, 0);
    }
}
