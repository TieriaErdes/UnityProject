using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf_Patrol_Behaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> WolfArea = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseRange = 10;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform WolfAreaObject = GameObject.FindGameObjectWithTag("WolfArea").transform;
        foreach (Transform t in WolfAreaObject)
            WolfArea.Add(t);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(WolfArea[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(WolfArea[Random.Range(0, WolfArea.Count)].position);

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("IsPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
            animator.SetBool("IsChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
