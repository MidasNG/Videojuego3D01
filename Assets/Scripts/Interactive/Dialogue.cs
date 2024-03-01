using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogue : Interactive
{
    private string textShown;
    private Coroutine speaking;
    private int textBoxAmount, currentBox, newBox;

    [SerializeField] private GameObject player;
    [SerializeField] private List<string> textList;
    [SerializeField] private TextMeshProUGUI target;
    [SerializeField] private Camera targetCamera, playerCamera;

    void Start()
    {
        textBoxAmount = textList.Count;
    }

    public override void Interact()
    {
        if (speaking == null)
        {
            player.GetComponent<PlayerControl>().DialogueFreeze(true);
            speaking = StartCoroutine(Speech());
            player.GetComponent<PlayerInput>().SwitchCurrentActionMap("dialogueActions");

            if (targetCamera != null && playerCamera != null)
            {
                targetCamera.enabled = true;
                playerCamera.enabled = false;
            }
        }

        else if (newBox < textBoxAmount - 1) newBox++;

        else
        {
            newBox = 0;

            textShown = null;
            speaking = null;
            StopAllCoroutines();

            target.transform.parent.gameObject.SetActive(false);

            player.GetComponent<PlayerControl>().DialogueFreeze(false);
            player.GetComponent<PlayerInput>().SwitchCurrentActionMap("normalActions");

            if (targetCamera != null && playerCamera != null)
            {
                targetCamera.enabled = false;
                playerCamera.enabled = true;
            }
        }
    }

    private IEnumerator Speech()
    {
        target.transform.parent.gameObject.SetActive(true);
        for (int i = 0; i < textBoxAmount; i++)
        {
            currentBox = newBox;
            for (int j = 0; j < textList[currentBox].ToCharArray().Length; j++)
            {
                if (newBox > currentBox) break;
                textShown = textShown + textList[currentBox].ToCharArray()[j].ToString();
                if (target != null) target.text = textShown;
                yield return new WaitForSeconds(.03f);
            }
            yield return new WaitUntil(() => newBox > currentBox);
            textShown = null;
        }
        yield return null;
    }
}
