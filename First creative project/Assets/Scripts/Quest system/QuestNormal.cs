using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestNormal
{
    public bool isActive;

    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed");
    }
}
