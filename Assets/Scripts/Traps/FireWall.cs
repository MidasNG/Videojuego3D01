using System.Collections;
using UnityEngine;

public class FireWall : TrapActivation
{
    private void Start()
    {
        foreach (ParticleSystem fire in GetComponentsInChildren<ParticleSystem>())
        {
            fire.Stop();
        }
    }

    public override void Activate()
    {
        StartCoroutine(StartMove());        
    }

    private IEnumerator StartMove()
    {
        yield return new WaitForSeconds(4);

        GetComponent<Collider>().enabled = true;
        foreach (ParticleSystem fire in GetComponentsInChildren<ParticleSystem>())
        {
            fire.Play();
        }

        float t = 0;
        while (true)
        {
            if (t >= 13) break;
            transform.Translate(new Vector3(0, 0, 6 * Time.deltaTime));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
