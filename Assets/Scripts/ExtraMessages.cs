using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExtraMessages : MonoBehaviour
{
    private string textShown;
    private int textBoxAmount, currentBox, newBox;
    private static int runeAmount;

    [SerializeField] private List<string> textList;
    [SerializeField] private TextMeshProUGUI target;
    [SerializeField] private bool final;

    void Start()
    {
        textBoxAmount = textList.Count;

        if (final)
        {
            textList.Clear();
            textList.Add("*click*");
            textBoxAmount = 1;
            StartCoroutine(Speech());
        }

    }

    public void Talk()
    {
        runeAmount++;

        if (runeAmount == 4)
        {
            textList.Add("¡Muachas gracias por ayudarme!");
            textList.Add("Ya esta abierta la puerta del tesoro.");
            textBoxAmount++;
        }
        else textList.Add("¡Te quedan " + (4 - runeAmount) + " runas!");

        textBoxAmount++;

        StartCoroutine(Speech());
    }

    private IEnumerator Speech()
    {
        target.transform.parent.gameObject.SetActive(true);
        for (int i = 0; i < textBoxAmount; i++)
        {
            currentBox = newBox;
            for (int j = 0; j < textList[currentBox].ToCharArray().Length; j++)
            {
                textShown = textShown + textList[currentBox].ToCharArray()[j].ToString();
                if (target != null) target.text = textShown;
                yield return new WaitForSeconds(.03f);
            }
            yield return new WaitForSeconds(2);
            newBox++;
            textShown = null;
        }
        target.transform.parent.gameObject.SetActive(false);
        yield return null;
    }
}