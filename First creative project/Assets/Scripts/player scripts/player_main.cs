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

    public QuestGiver quest;
    public int Experience;

    public InventoryHolder inventory;


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
        healthPointsModification();
        hungerPointsModification();
        thistPointModification();


        if (quest.currentQuest.isActive)
        {
            // ПРОСТО ПРИМЕР
            //quest.currentQuest.goal.EnemyKilled();
            CheackGoalReached();

            //if (quest.currentQuest.goal.goalType == GoalType.Survive)
            //    quest.currentQuest.goal.Surviving();

            //if (quest.currentQuest.goal.goalType == GoalType.Collect_sticks)
            //    quest.currentQuest.goal.currentAmount = inventory.PrimaryInventorySystem.GetCountOfDesireItems("Branch");



            if (quest.currentQuest.goal.IsReached())
            {
                Experience += quest.currentQuest.experienceReward;
                quest.currentQuest.Complete();
                quest.GetNextQuest();
            }

        }
    }


    // Функция изменения количества выносливости
    private void staminaPointsModification()
    {
        if (pm.state == player_movement.MovementState.climbing || pm.state == player_movement.MovementState.sprinting)
            staminaPoints -= 12 * Time.deltaTime;
        else if (pm.state == player_movement.MovementState.walkind && pm.isGrounded && (staminaPoints < staminaPointsMax))
            staminaPoints += 7.5f * Time.deltaTime;
    }

    private void healthPointsModification()
    {
        //<summary>
        //TODO: Сделать механику восстановления хп
    }

    private void hungerPointsModification()
    {
        if (pm.state == player_movement.MovementState.climbing || pm.state == player_movement.MovementState.sprinting)
            hungerPoints -= 0.12f * Time.deltaTime;
        else if (pm.state == player_movement.MovementState.walkind && pm.isGrounded && (staminaPoints < staminaPointsMax))
            hungerPoints -= 0.08f * Time.deltaTime;
    }

    private void thistPointModification()
    {
        if (pm.state == player_movement.MovementState.climbing || pm.state == player_movement.MovementState.sprinting)
            thirstPoints -= 0.15f * Time.deltaTime;
        else if (pm.state == player_movement.MovementState.walkind && pm.isGrounded && (staminaPoints < staminaPointsMax))
            thirstPoints -= 0.1f * Time.deltaTime;
    }


    private void CheackGoalReached()
    {
        switch (quest.currentQuest.goal.goalType)
        {
            case GoalType.Kill:
                break;
            case GoalType.Kill_rabbit:
                break;
            case GoalType.Gathering:
                break;
            case GoalType.Survive:
                quest.currentQuest.goal.Surviving();
                break;
            case GoalType.Collect_eggs:
                break;
            case GoalType.Collect_sticks:
                //Debug.Log("Working");
                quest.currentQuest.goal.currentAmount = inventory.PrimaryInventorySystem.GetCountOfDesireItems("Branch");
                break;
            case GoalType.Collect_leaves:
                break;
            case GoalType.Find:
                break;
            default:
                break;
        }
    }
}
