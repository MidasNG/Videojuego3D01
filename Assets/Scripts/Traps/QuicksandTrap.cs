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
