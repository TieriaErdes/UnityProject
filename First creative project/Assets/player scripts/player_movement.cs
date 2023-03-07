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

        //���� ������ ������� �� ����� ������� ������ player
        jumpForce /= rb.mass;

        startYScale = transform.localScale.y;
        //startYScale = playerHeight;
    }

    void Update()
    {
        
        // �������� �����������
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        myInput();
        SpeedControl();
        stateHandler();

        // ����������
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    // ���������� ������ �������, ��� ���������
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


        // ������ �������� � �������
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        // ���������� �������� � �������
        if (Input.GetKeyUp(crouchKey))
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    }

    private void stateHandler()
    {
        // ����������
        if (climbing)
        {
            state = MovementState.climbing;
            movementSpeed = climbingSpeed;
        }

        // �������� � �������
        else if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            movementSpeed = crouchSpeed;
        }

        // ������
        else if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            movementSpeed = sprintSpeed;
        }

        // ������� ���
        else if (isGrounded)
        {
            state = MovementState.walkind;
            movementSpeed = walkSpeed;
        }

        // � �������
        else
        {
            state = MovementState.air;

        }
    }

    private void movePlayer()
    {
        move_Direction = orientation.forward * verticalInput + orientation.right * horisontalInput;

        // �� �����
        if (isGrounded)
            rb.AddForce(move_Direction.normalized * movementSpeed * 5.0f, ForceMode.Force);

        // � �������
        else if (!isGrounded)
            rb.AddForce(move_Direction.normalized * movementSpeed * 10.0f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // ���������� �������� �����������
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

