using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public abstract void Interact(); //SIN CÓDIGO, obligatorio sobreescribir
    //Opción 2: public virtual void Interact();   permite elegir si se sobreescribe o no, lleva su código, se puede llamar con base.nombre();
}
