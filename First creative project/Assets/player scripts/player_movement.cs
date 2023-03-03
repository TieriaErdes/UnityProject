using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform GrondCheck;
    [SerializeField] LayerMask Terrain;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Сила прыжка зависит от массы объекта группы player
        jumpForce /= rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        // Horisontal и Vertical это названия групп, которые принимают ввод определённых клавиш
        // (посмротреть можно в настройках проекта, во вкладке Input manager
        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (IsGrounded())
            rb.velocity = new Vector3(horisontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }


    bool IsGrounded()
    {
        return Physics.CheckSphere(GrondCheck.position, 0.1f, Terrain);
    }
}
