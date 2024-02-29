using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private GameObject deleteTreasureEmpty, lastGhost, mainGate;

    public void Activate()
    {
        deleteTreasureEmpty.SetActive(true);
        lastGhost.SetActive(true);
        mainGate.GetComponent<MainGate>().GetRune("CLEAR");
        mainGate.transform.localPosition = new Vector3(mainGate.transform.localPosition.x, 186f, mainGate.transform.localPosition.z);
    }
}
