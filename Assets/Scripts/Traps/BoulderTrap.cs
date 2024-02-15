using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrap : TrapActivation
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public override void Activate()
    {
        rb.useGravity = true;
    }
}
