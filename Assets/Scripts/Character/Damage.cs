using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    private int health = 3;
    [SerializeField] private List<Image> hearts = new List<Image>();

    private void Update()
    {
        if (transform.position.y < -40)
        {
            health--;
            hearts[health].gameObject.SetActive(false);
            transform.position = new Vector3(-28, -6.5f, -5);
        }

        if (health == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hazard"))
        {
            health--;
            hearts[health].gameObject.SetActive(false);
        }
    }
}
