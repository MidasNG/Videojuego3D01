using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGate : Interactive
{
    [SerializeField] private bool runeA, runeB, runeC, runeD;
    private float speed = 5f, t;

    void Update()
    {
        if (runeA && runeB && runeC && runeD)
        {
            t += Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(2.5f, 5.5f, t), transform.position.z); //186, 188
        }
    }

    public override void Interact()
    {
        runeD = true;
    }
}
