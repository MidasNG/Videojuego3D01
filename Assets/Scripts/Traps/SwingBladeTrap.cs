using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBladeTrap : TrapActivation
{
    private float t;
    [SerializeField] private bool startOnPlay;
    [SerializeField] private AnimationCurve curve;

    private void Start()
    {
        if (startOnPlay) StartCoroutine(Swing());    
    }

    public override void Activate()
    {
        StartCoroutine(Swing());
    }
    
    private IEnumerator Swing()
    {
        while (true)
        {
            while (t < 1)
            {
                t += Time.deltaTime;
                transform.eulerAngles = new Vector3 (0, 0, Mathf.Lerp(-45, 45, curve.Evaluate(t)));
                yield return new WaitForEndOfFrame();
            }

            t = 0;
            yield return new WaitForSeconds(.5f);

            while (t < 1)
            {
                t += Time.deltaTime;
                transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(45, -45, curve.Evaluate(t)));
                yield return new WaitForEndOfFrame();
            }

            t = 0;
            yield return new WaitForSeconds(.5f);
        }
    }
}
