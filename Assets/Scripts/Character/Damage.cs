using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    private int health = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hazard"))
        {
            health--;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
