using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotBehaviorRunaway : BotBehaviorState
{
    ExpBombWork closestBomb;
    HashSet<ExpBombWork> bombsAround;


    override public void Enter()
    {

        Debug.Log("Enter RUNAWAY behavior for " + context.name);
    }

    override public void Exit()
    {
        Debug.Log("Exit RUNAWAY behavior for " + context.name);
    }


    public override void Update()
    {
        //Debug.Log("Update RUNAWAY behavior");



        bombsAround = ExpBombWork.FindBombsWithinRange(context.transform.position, bombTriggerRange);

        if (bombsAround.Count > 0)
        {
            NavMeshHit hit;

            NavMeshQueryFilter mask = new NavMeshQueryFilter();
            mask.areaMask = (1 << NavMesh.GetAreaFromName("Walkable"));

            NavMesh.SamplePosition(context.transform.position, out hit, bombTriggerRange, mask.areaMask);
            
            Vector3 testPosition = hit.position;
            context.MoveTo(testPosition);
        }
        else
        {
            context.SetBehavior(new BotBehaviorSearch());
        }


    }


}
