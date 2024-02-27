using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsjInteractuar : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    RaycastHit hitInfo;
    //    if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
    //    {
    //        if (hitInfo.collider.CompareTag("fantasma"))
    //        {
    //            print("Pulsar <e> para interactuar");
    //            canvas.enabled = true;
    //        }
    //        else
    //        {
    //            canvas.enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        print("No hay nada");
    //    }
    //}

    private void OnCollisionEnter(Collision other)
    {
        print("estaba tocando");
        // Verifica si el objeto con el que colisionamos tiene el tag "fantasma"
        if (other.gameObject.CompareTag("fantasma"))
        {
            // Activa el canvas si el tag es "fantasma"
            canvas.gameObject.SetActive(true);
        }
    }
}
