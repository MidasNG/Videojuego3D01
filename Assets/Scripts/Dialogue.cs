using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : Interactive
{
    private Coroutine speaking;
    private int textBoxAmount, currentBox, newBox;

    [SerializeField] private string textShown;
    [SerializeField] private TextMeshProUGUI target;
    [SerializeField] private List<string> textList;

    void Start()
    {
        textBoxAmount = textList.Count;
    }

    public override void Interact()
    {
        if (speaking == null) speaking = StartCoroutine(Speech());
        else if (newBox < textBoxAmount-1) newBox++;
    }

    private IEnumerator Speech()
    {
        for (int i = 0; i < textBoxAmount;)
        {
            currentBox = newBox;
            for (int j = 0; j < textList[currentBox].ToCharArray().Length; j++)
            {
                if (newBox > currentBox) break;
                textShown = textShown + textList[currentBox].ToCharArray()[j].ToString();
                if (target != null) target.text = textShown;
                yield return new WaitForSeconds(.25f);
            }
            Debug.Log("Esperando interacción");
            yield return new WaitUntil(() => newBox > currentBox);
            textShown = null;
        }
    }
}
