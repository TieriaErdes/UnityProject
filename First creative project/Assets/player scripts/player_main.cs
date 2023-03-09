using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_main : MonoBehaviour
{
    Rigidbody rb;
    public player_movement pm;

    [Header("Main dependency")]
    public float hitPoints = 100;
    public float hungerPoints = 100;
    public float thirstPoints = 100;
    public float staminaPoints = 100;

    private float hitPoitnsMax = 100;
    private float hungerPointsMax = 100;
    private float thirstPointsMax = 100;
    private float staminaPointsMax = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = gameObject.GetComponent<player_movement>();
        

    }

    // Update is called once per frame
    void Update()
    {
        staminaPointsModification();
    }


    // Функция изменения количества выносливости
    private void staminaPointsModification()
    {
        if (pm.state == player_movement.MovementState.climbing || pm.state == player_movement.MovementState.sprinting)
            staminaPoints -= 12 * Time.deltaTime;
        else if (pm.state == player_movement.MovementState.walkind && pm.isGrounded && (staminaPoints < staminaPointsMax))
            staminaPoints += 7.5f * Time.deltaTime;
    }
}
