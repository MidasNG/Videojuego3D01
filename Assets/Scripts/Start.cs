using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Start: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
