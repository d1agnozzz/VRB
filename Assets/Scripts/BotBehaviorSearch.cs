using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotBehaviorSearch : BotBehaviorState
{
    

    private bool isWandering;
    private NavMeshAgent agent;
    private Vector3 destinationCurrent;
    
    

    #region ENTER
    override public void Enter()
    {
        Debug.Log("Enter SEARCH behavior");
        isWandering = false;
        agent = context.GetComponent<NavMeshAgent>();
    }
    #endregion

    #region EXIT
    public void Exit()
    {
        Debug.Log("Exit SEARCH behavior");
    }
    #endregion

    // возвращает случайную точку с навмэша 
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }



    override public void Update()
    {
        Debug.Log("Update SEARCH behavior");

        if (isWandering == false)
        {
            Vector3 destinationNew = RandomNavSphere(context.transform.position, context.wanderRadius, -1);
            context.MoveTo(destinationNew);
            destinationCurrent = destinationNew;
            isWandering = true;

        }
        if (Vector3.Distance(context.transform.position, destinationCurrent) < 0.1)
        {
            isWandering = false;
        }
    }
}
