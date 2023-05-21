using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class camera_script : MonoBehaviour
{
    /// <summary>
    /// IN THIS SCRIPT VISiBILITY OF CURSOR
    /// IN THIS SCRIPT VISiBILITY OF CURSOR
    /// IN THIS SCRIPT VISiBILITY OF CURSOR
    /// </summary>

    public float sensativityX;
    public float sensativityY;
    float rotationX;
    float rotationY;

    public Transform orientation;

    [SerializeField] GameObject CentreMarker;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Возврат курсора
        if (Keyboard.current.altKey.wasPressedThisFrame && !Cursor.visible)
        {
            CentreMarker.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        // Скрытие курсора
        else if (Keyboard.current.altKey.wasPressedThisFrame)
        {
            CentreMarker.SetActive(true);   
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensativityX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensativityY;

        if (!Cursor.visible)
        {
            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
            orientation.rotation = Quaternion.Euler(0, rotationY, 0);
        }
    }
}
