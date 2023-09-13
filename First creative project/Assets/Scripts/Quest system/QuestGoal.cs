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
        return (currentAmount > requiredAmount);
    }

    // опнярн опхлеп
    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
            currentAmount++;
    }

    public void Surviving()
    {
        if (goalType == GoalType.Survive)
        {
            currentAmount++;
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
    Find
}
