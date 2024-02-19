using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : TrapActivation
{
    public override void Activate()
    {
        StartCoroutine(StartMove());
        GetComponent<Collider>().enabled = true;
    }

    private IEnumerator StartMove()
    {
        yield return new WaitForSeconds(6);
        float t = 0;
        while (true)
        {
            if (t >= 11) break;
            transform.Translate(new Vector3(0, 0, 6 * Time.deltaTime));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
