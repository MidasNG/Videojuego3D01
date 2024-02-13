using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private float t, speed = 10f;

    private void Start()
    {
        StartCoroutine(Spikes());
    }

    private IEnumerator Spikes()
    {
        while (true)
        {
            t = 0;
            StartCoroutine(Activate());
            yield return new WaitForSeconds(2);
            t = 0;
            StartCoroutine(Deactivate());
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator Deactivate()
    {
        while (t < 1)
        {
            t += Time.deltaTime * speed / 3;
            transform.localPosition = new Vector3(0, Mathf.Lerp(0, -2.1f, t), 0);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator Activate()
    {
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.localPosition = new Vector3(0, Mathf.Lerp(-2.1f, 0, t), 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
