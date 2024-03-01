using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private Camera playerCam;

    private void Update()
    {
        if (Physics.SphereCast(transform.position - transform.rotation * new Vector3(0, 0, 2f) + new Vector3(0, 1, 0), 2f, transform.forward, out RaycastHit hit, 2f) && hit.collider.GetComponent<Interactive>() != null && interactText != null && playerCam.enabled == true && Time.timeScale == 1 && !(hit.collider.GetComponent<Rune>() != null && hit.collider.GetComponent<Rune>().CheckActivation()))
        {
            interactText.text = "E";
        }
        else if (interactText != null) interactText.text = null;
    }

    private void OnInteract()
    {
        if (Physics.SphereCast(transform.position - transform.rotation * new Vector3(0, 0, 2f), 2f, transform.forward, out RaycastHit hit, 2f) && hit.collider != null)
        {
            if(hit.collider.gameObject.GetComponent<Interactive>() != null) hit.collider.gameObject.GetComponent<Interactive>().Interact();
        }
    }

}
