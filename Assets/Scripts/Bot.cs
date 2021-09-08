using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Bot : MonoBehaviour
{
    private BotBehaviorState behaviorCurrent;
    private NavMeshAgent agent;
    public float wanderRadius;
    


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetBehavior(new BotBehaviorRunaway());
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            Debug.Log("BOMB! Runaway");
        }
        else if (other.gameObject.CompareTag("Player") && !(behaviorCurrent is BotBehaviorRunaway))
        {
            Debug.Log("Player! Attack");
        }
    }

    private void Update()
    {
        if (behaviorCurrent != null)
            behaviorCurrent.Update();
    }



    private void SetBehavior(BotBehaviorState newBehavior)
    {
        if (behaviorCurrent != null)
            behaviorCurrent.Exit();

        behaviorCurrent = newBehavior;
        behaviorCurrent.SetContext(this);
        behaviorCurrent.Enter();
    }

    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
