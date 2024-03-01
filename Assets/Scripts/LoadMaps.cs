using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMaps : MonoBehaviour
{
    [SerializeField] private GameObject targetMap, alwaysLoadedTraps;
    [SerializeField] private bool loadNotUnload;
    [SerializeField] private float xOldPos, YOldPos, optionalYOffset;

    private void Start()
    {
        if (alwaysLoadedTraps != null) alwaysLoadedTraps.transform.position = new Vector3(100, YOldPos - optionalYOffset, alwaysLoadedTraps.transform.position.z);
    }

    public void LoadUnload()
    {
        if (targetMap != null && loadNotUnload) targetMap.SetActive(true);

        else if (targetMap != null) targetMap.SetActive(false);

        if (alwaysLoadedTraps != null && loadNotUnload) alwaysLoadedTraps.transform.position = new Vector3(xOldPos, YOldPos, alwaysLoadedTraps.transform.position.z);

        else if (alwaysLoadedTraps != null) alwaysLoadedTraps.transform.position = new Vector3(100, YOldPos - optionalYOffset, alwaysLoadedTraps.transform.position.z);
    }
}
