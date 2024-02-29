using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rune : Interactive
{
    private bool activated;

    [SerializeField] private string rune;
    [SerializeField] private MainGate Gate;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource clipSource;
    [SerializeField] private TrapActivation targetTrap;
    [SerializeField] private GameObject redRune, blueRune;
    [SerializeField] private Camera targetCamera, playerCamera;

   public override void Interact()
   {
        if (!activated)
        {
            activated = true;
            StartCoroutine(RuneObtained());
            if (Gate != null)
            {
                Gate.GetRune(rune);
            }
        }
   }

    private IEnumerator RuneObtained()
    {
        if (targetCamera != null)
        {
            targetCamera.enabled = true;
            playerCamera.enabled = false;
            player.GetComponent<PlayerInput>().DeactivateInput();

            yield return new WaitForSeconds(2.5f);
            if (redRune != null && blueRune != null)
            {
                redRune.SetActive(false);
                if (clipSource != null && clip != null) clipSource.PlayOneShot(clip);
                blueRune.SetActive(true);
            }
            yield return new WaitForSeconds(2.5f);

            targetCamera.enabled = false;
            playerCamera.enabled = true;
            player.GetComponent<PlayerInput>().ActivateInput();
        }

        yield return new WaitForSeconds(1);

        if (targetTrap != null)
        {
            targetTrap.Activate();
        }

        yield return null;
    }
}
