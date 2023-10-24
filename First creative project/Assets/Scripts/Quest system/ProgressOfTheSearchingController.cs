using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressOfTheSearchingController : MonoBehaviour
{
    public SphereCollider myCollider;
    [SerializeField] private float searchingRadius = 5.0f; 

    public QuestGiver quest;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = searchingRadius;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            quest.currentQuest.goal.FindTheSpot();

            if (quest.currentQuest.goal.goalType == GoalType.Find)
                Destroy(this.gameObject);
        }
        else
            return;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            return;
        }
        else
            return;
    }
}
