using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_climbing : MonoBehaviour
{
    Rigidbody rb;
    player_main player;

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float climbingSpeed = 3f;
    [SerializeField] float jump_backForce = -5f;

    //[SerializeField] Transform ClimbingCheck = new Transform[4];
    [SerializeField] Transform ClimbingCheck;
    [SerializeField] LayerMask Terrain;
    [SerializeField] LayerMask Tree;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<player_main>();
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < ClimbingCheck.Length; i++)
        //    if (isClimbing(i))
        //    {
        //        rb.velocity = new Vector3()
        //    }

        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if (Input.GetButtonDown("Jump") && isClimbing())
            rb.velocity = new Vector3(horisontalInput, rb.velocity.y, jump_backForce);

        if ((verticalInput > 0) && isClimbing()) //&& (player.staminaPoints > 0))
        {
            rb.velocity = new Vector3(horisontalInput * movementSpeed, climbingSpeed, rb.velocity.z);
        }
        else if ((verticalInput < 0) && isClimbing())
            rb.velocity = new Vector3(horisontalInput * movementSpeed, -climbingSpeed, rb.velocity.z);
        


    }


    bool isClimbing()
    {
        return Physics.CheckSphere(ClimbingCheck.position, 0.2f, Terrain) || Physics.CheckSphere(ClimbingCheck.position, 0.2f, Tree);
    }

    //bool isClimbing()
    //{
    //    Console.WriteLine("Climbing!!!");
    //    return Physics.Raycast(ClimbingCheck.position, Vector3.forward, 0.1f);
    //}
}
