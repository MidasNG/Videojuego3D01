using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : Interactive
{
    [SerializeField] private char rune;
    [SerializeField] private MainGate Gate;
    [SerializeField] private TrapActivation targetTrap;
    [SerializeField] private Camera targetCamera, playerCamera;

   public override void Interact()
   {
        StartCoroutine(RuneObtained());
        
        if (Gate != null)
        {
            Gate.GetRune(rune);
        }
   }

    private IEnumerator RuneObtained()
    {
        if (targetCamera != null)
        {
            targetCamera.enabled = true;
            playerCamera.enabled = false;

            yield return new WaitForSeconds(5);

            targetCamera.enabled = false;
            playerCamera.enabled = true;
        }

        yield return new WaitForSeconds(2);

        if (targetTrap != null)
        {
            targetTrap.Activate();
        }

        yield return null;
    }
}