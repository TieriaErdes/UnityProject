using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{

    float xRot;
    float yRot;
    float xRotCurrent;
    float yRotCurrent;
    [SerializeField] Camera player;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] float sensivity = 5f;
    [SerializeField] float smoothTime = 0.1f;
    float currentVelosityX;
    float currentVelosityY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xRot += Input.GetAxis("Mouse X") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity;

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        xRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);

        player.transform.rotation = Quaternion.Euler(-yRot, xRot, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, xRot, 0f);
    }
}
