using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BotBehaviorState
{
    [HideInInspector] public Bot context;
    [HideInInspector] protected float bomberTriggerRange = Bot.bomberTriggerRange;
    [HideInInspector] protected float bombTriggerRange = Bot.bombTriggerRange;


    public void SetContext(Bot bot)
    {
        context = bot;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }


    public virtual void Enter() { }

    public virtual void Exit() { }

    public abstract void Update();
}
