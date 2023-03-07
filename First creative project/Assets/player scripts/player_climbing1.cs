using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_climbing1 : MonoBehaviour
{
    [Header("Raference")]
    public Transform orientation;
    public Rigidbody rb;
    public player_movement pm;
    public LayerMask whatIsWall;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;
    private bool climbing;

    [Header("Climb jumping")]
    public float climbJumpUpForce;
    public float climbJumpBackForce;

    public KeyCode jumpKey = KeyCode.Space;
    public int climbJumps;
    private int ClimbJumpsLeft;

    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float WallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = gameObject.GetComponent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        WallCheck();
        StateMachine();

        if (climbing)
            ClimbingMovement();
    }


    private void StateMachine()
    {
        // Подъём
        if (wallFront && Input.GetKey(KeyCode.W) && (WallLookAngle < maxWallLookAngle))
        {
            if (!climbing && (climbTimer > 0))
                StartClimbing();

            // отсчёт времени карабканья
            if (climbTimer > 0)
                climbTimer -= Time.deltaTime;

            if (climbTimer < 0)
                StopClimbing();

        }

        else
        {
            if (climbing)
                StopClimbing();
        }
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        WallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        if (pm.isGrounded)
            climbTimer = maxClimbTime;
    }


    private void StartClimbing()
    {
        climbing = true;
        pm.climbing = true;
    }

    private void StopClimbing()
    { 
        climbing= false;
        pm.climbing = false;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);

    }
}
