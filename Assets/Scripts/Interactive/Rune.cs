using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rune : Interactive
{
    private bool activated;

    [SerializeField] private bool tomb;
    [SerializeField] private string rune;
    [SerializeField] private MainGate Gate;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource clipSource;
    [SerializeField] private TrapActivation targetTrap;
    [SerializeField] private GameObject redRune, blueRune, redPillar, bluePillar;
    [SerializeField] private Camera targetCamera, playerCamera;

   public override void Interact()
   {
        if (!activated)
        {
            activated = true;
            StartCoroutine(RuneObtained());
            GetComponent<ExtraMessages>()?.Talk();

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

            if (clipSource != null && clip != null) clipSource.PlayOneShot(clip);

            yield return new WaitForSeconds(2.5f);
            if (redRune != null && blueRune != null)
            {
                redRune.SetActive(false);
                blueRune.SetActive(true);
            }
            if (redPillar != null && bluePillar != null)
            {
                redPillar.SetActive(false);
                bluePillar.SetActive(true);
            }
            yield return new WaitForSeconds(2.5f);

            targetCamera.enabled = false;
            playerCamera.enabled = true;
            player.GetComponent<PlayerInput>().ActivateInput();
            if (tomb) player.transform.position = new Vector3(-28, -6.5f, -5);
        }

        yield return new WaitForSeconds(1);

        if (targetTrap != null)
        {
            targetTrap.Activate();
        }

        yield return null;

    }

    public bool CheckActivation()
    {
        return activated;
    }
}
