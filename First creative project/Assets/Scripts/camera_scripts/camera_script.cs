using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera_script : MonoBehaviour
{

    //float xRot;
    //float yRot;
    //float xRotCurrent;
    //float yRotCurrent;
    //[SerializeField] Camera player;
    //[SerializeField] GameObject playerGameObject;
    //[SerializeField] float sensivity = 5f;
    //[SerializeField] float smoothTime = 0.1f;
    //float currentVelosityX;
    //float currentVelosityY;

    // Start is called before the first frame update

    public float sensativityX;
    public float sensativityY;
    float rotationX;
    float rotationY;

    public Transform orientation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //xRot += Input.GetAxis("Mouse X") * sensivity;
        //yRot += Input.GetAxis("Mouse Y") * sensivity;
        //
        //xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        //xRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);
        //
        //player.transform.rotation = Quaternion.Euler(-yRot, xRot, 0f);
        //playerGameObject.transform.rotation = Quaternion.Euler(0f, xRot, 0f);


        // Возврат курсора
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        // Скрытие курсора
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
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
