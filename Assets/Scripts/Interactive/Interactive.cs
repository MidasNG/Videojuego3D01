using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public abstract void Interact(); //SIN C�DIGO, obligatorio sobreescribir
    //Opci�n 2: public virtual void Interact();   permite elegir si se sobreescribe o no, lleva su c�digo, se puede llamar con base.nombre();
}
