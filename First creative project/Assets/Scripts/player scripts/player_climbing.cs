using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_climbing : MonoBehaviour
{
    // 
    // Данный скрипт отвечает за механику карабканья игрока.
    // Сам процесс осуществуется с помощью компонента Rigidbody
    // и скрипта player_movement. Так же реализована механика прыжков вверх и назад
    // время карабканья игрока ограничено его выносливостью (p_main.staminaPoints)
    //

    [Header("Raference")]
    public Transform orientation;
    public Rigidbody rb;
    public player_movement pm;
    public player_main p_Main;
    public LayerMask whatIsWall;

    [Header("Climbing")]
    public float climbSpeed;
    //public float maxClimbTime;
    //public float climbTimer;
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

    private Transform lastWall;
    private Vector3 lastWallNormal;
    public float minwallNormalAngleChange;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = gameObject.GetComponent<player_movement>();
        p_Main = gameObject.GetComponent<player_main>();

        //maxClimbTime = p_Main.staminaPoints;

        lastWall = frontWallHit.transform;
        lastWallNormal = frontWallHit.normal;
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
            if (!climbing && (p_Main.staminaPoints > 1))
                StartClimbing();

            // отсчёт времени карабканья
            //if (climbTimer > 0)
            //    climbTimer = p_Main.staminaPoints;

            if (p_Main.staminaPoints < 1)
                StopClimbing();

        }
        else
        {
            if (climbing)
                StopClimbing();
        }

        // прыжки при карабканье
        if (wallFront && Input.GetKeyDown(jumpKey) && (ClimbJumpsLeft > 0))
            Climbjump();
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        WallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        bool newWall = frontWallHit.transform != lastWall || Math.Abs(Vector3.Angle(lastWallNormal, frontWallHit.normal)) > minwallNormalAngleChange;


        if (pm.isGrounded || (wallFront && newWall))
        {
            //climbTimer = maxClimbTime;
            //if (climbTimer < maxClimbTime)
            //    climbTimer += 10 * Time.deltaTime;
            ClimbJumpsLeft = climbJumps;
        }
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

    private void Climbjump()
    {
        Vector3 forceToApply = transform.up * climbJumpUpForce + frontWallHit.normal * climbJumpBackForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);

        ClimbJumpsLeft--;
    }
}
