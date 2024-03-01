using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    private float sensitivity = 6, mouseMovementX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Time.timeScale == 1) transform.Rotate(0, mouseMovementX * sensitivity * Time.fixedDeltaTime, 0);
    }

    private void OnMouse(InputValue value)
    {
        mouseMovementX = value.Get<Vector2>().x;
    }
}
