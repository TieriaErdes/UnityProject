using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    //[SerializeField] Transform GrondCheck;
    //[SerializeField] LayerMask Terrain;

    ////[SerializeField] GameObject Player;
    //CharacterController player;
    //Vector3 move_Direction;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    player = GetComponent<CharacterController>();

    //    // Сила прыжка зависит от массы объекта группы player
    //    jumpForce /= rb.mass;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Horisontal и Vertical это названия групп, которые принимают ввод определённых клавиш
    //    // (посмротреть можно в настройках проекта, во вкладке Input manager
    //    //float horisontalInput = Input.GetAxis("Horizontal");
    //    //float verticalInput = Input.GetAxis("Vertical");
    //    //
    //    //if (IsGrounded())
    //    //    rb.velocity = new Vector3(horisontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

    //    //float x_move = Input.GetAxis("Horizontal");
    //    //float z_move = Input.GetAxis("Vertical");
    //    //if (player.isGrounded)
    //    //{
    //    //    move_Direction = new Vector3(x_move, 0f, z_move);
    //    //    move_Direction = transform.TransformDirection(move_Direction);
    //    //}
    //    //move_Direction.y -= 1;
    //    //player.Move(move_Direction * movementSpeed * Time.deltaTime);

    //    //if (Input.GetButtonDown("Jump") && IsGrounded())
    //    //{
    //    //    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    //    //}


    //}


    //bool IsGrounded()
    //{
    //    return Physics.CheckSphere(GrondCheck.position, 0.1f, Terrain);
    //}

    public Transform orientation;

    public float horisontalInput;
    public float verticalInput;

    public float speed_move = 5f;
    float x_move;
    float z_move;
    CharacterController player;
    Vector3 move_Direction;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();

        rb.freezeRotation = true;

        //Сила прыжка зависит от массы объекта группы player
        jumpForce /= rb.mass;
    }

    void Update()
    {
        //x_move = Input.GetAxis("Horizontal");
        //z_move = Input.GetAxis("Vertical");
        //if (player.isGrounded)
        //{
        //    move_Direction = new Vector3(x_move, 0f, z_move);
        //    move_Direction = transform.TransformDirection(move_Direction);
        //}
        //if (Input.GetButtonDown("Space") && player.isGrounded)
        //    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        //move_Direction.y -= 1;
        //player.Move(move_Direction * speed_move * Time.deltaTime);
        //
        //if (Input.GetButtonDown("Space") && player.isGrounded)
        //    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //Horisontal и Vertical это названия групп, которые принимают ввод определённых клавиш
        // (посмротреть можно в настройках проекта, во вкладке Input manager

        myInput();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void myInput()
    {
        horisontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        move_Direction = orientation.forward * verticalInput + orientation.right * horisontalInput;

        rb.AddForce(move_Direction.normalized * movementSpeed * 5.0f, ForceMode.Force);
    }
}
