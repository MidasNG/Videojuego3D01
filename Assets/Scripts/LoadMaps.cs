using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMaps : MonoBehaviour
{
    [SerializeField] private GameObject targetMap;
    [SerializeField] private bool loadNotUnload;

    public void LoadUnload()
    {
        if (targetMap != null && loadNotUnload) targetMap.SetActive(true);

        else if (targetMap != null) targetMap.SetActive(false);
    }
}
