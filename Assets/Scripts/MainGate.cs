using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGate : MonoBehaviour
{
    [SerializeField] private bool runeA, runeB, runeC, runeD;
    private float speed = 5f, t;

    void Start()
    {
        
    }

    void Update()
    {
        if (runeA && runeB && runeC && runeD)
        {
            t += Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(0, 2, t), transform.position.z); //186, 188
        }
    }
}
