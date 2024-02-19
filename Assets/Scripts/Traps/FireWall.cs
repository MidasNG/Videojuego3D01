using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : Interactive
{

    private void Start()
    {
        
    }

    public override void Interact()
    {
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        while (true)
        {
            transform.Translate(new Vector3(0, 0, 6 * Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
    }
}
