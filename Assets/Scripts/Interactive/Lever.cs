using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : Interactive
{
    private float t;
    private bool active;
    [SerializeField] private GameObject target;

    public override void Interact() //Sobreescribir el método para que sea diferente para cada tipo de objeto
    {
        active = !active;
        if (target.GetComponent<TrapActivation>() != null) target.GetComponent<TrapActivation>().Activate();
        if (target.GetComponent<Interactive>() != null) target.GetComponent<Interactive>().Interact();
        t = 0;
    }

    private void Update()
    {
        t += 2 * Time.deltaTime;
        if (active) transform.eulerAngles = new Vector3(Mathf.Lerp(135, 45, t), 90, 90);
        else transform.eulerAngles = new Vector3(Mathf.Lerp(45, 135, t), 90, 90);
    }
}
