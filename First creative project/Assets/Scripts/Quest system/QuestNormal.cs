using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System / Quest")]
[System.Serializable]
public class QuestNormal: ScriptableObject
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
