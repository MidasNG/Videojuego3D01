using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactive
{
    public override void Interact() //Sobreescribir el método para que sea diferente para cada tipo de objeto
    {
        print("Activado.");
        transform.Rotate(45, 0, 0);
    }
}
