using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_movement : MonoBehaviour
{

    Rigidbody rb;

    [Header("Movement")]
    public float movementSpeed = 5f;
    public float walkSpeed;
    public float sprintSpeed;
    public float climbingSpeed;
    public float groundDrag;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    [SerializeField] float jumpForce = 5f;
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public float airMultiplier;

    public Transform orientation;

    public MovementState state;
    public enum MovementState
    {
        walkind,
        sprinting,
        climbing,
        crouching,
        air
    }

    public bool climbing;

    public float horisontalInput;
    public float verticalInput;

    Vector3 move_Direction;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        //Сила прыжка зависит от массы объекта группы player
        jumpForce /= rb.mass;

        startYScale = transform.localScale.y;
        //startYScale = playerHeight;
    }

    void Update()
    {
        
        // Проверка поверхности
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        myInput();
        SpeedControl();
        stateHandler();

        // скольжение
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    // Вызывается каждую секунду, без пропусков
    private void FixedUpdate()
    {
        movePlayer();
    }

    private void myInput()
    {
        horisontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // readyToJump = false;
            Jump();
        }
        //Invoke(nameof(ResetJump), jumpCooldown);


        // начало движения в присяде
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        // завершение движения в присяде
        if (Input.GetKeyUp(crouchKey))
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    }

    private void stateHandler()
    {
        // карабканье
        if (climbing)
        {
            state = MovementState.climbing;
            movementSpeed = climbingSpeed;
        }

        // движение в присяде
        else if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            movementSpeed = crouchSpeed;
        }

        // Спринт
        else if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            movementSpeed = sprintSpeed;
        }

        // Обычный шаг
        else if (isGrounded)
        {
            state = MovementState.walkind;
            movementSpeed = walkSpeed;
        }

        // В воздухе
        else
        {
            state = MovementState.air;

        }
    }

    private void movePlayer()
    {
        move_Direction = orientation.forward * verticalInput + orientation.right * horisontalInput;

        // на земле
        if (isGrounded)
            rb.AddForce(move_Direction.normalized * movementSpeed * 5.0f, ForceMode.Force);

        // в воздухе
        else if (!isGrounded)
            rb.AddForce(move_Direction.normalized * movementSpeed * 10.0f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Огринчение скорости перемещения
        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}

