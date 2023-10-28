using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    // опнярн опхлеп
    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
            currentAmount++;
    }
    // опнярн опхлеп

    public void Surviving()
    {
        if (goalType == GoalType.Survive)
        {
            //currentAmount++;
            currentAmount = (int)Time.unscaledTime;
        }
    }

    public void FindTheSpot()
    {
        if (goalType == GoalType.Find)
        {
            currentAmount++;

            Debug.Log("The spot is find");
        }
    }

    
}

public enum GoalType
{
    Kill,
    Kill_rabbit,
    Gathering,
    Survive,
    Collect_eggs,
    Collect_sticks,
    Collect_leaves,
    Find,
    Collect_food
}
