using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicksandTrap : TrapActivation
{
    public override void Activate()
    {
        foreach (Collider collider in gameObject.GetComponents<Collider>())
        {
            collider.isTrigger = true;
        }
    }
}
