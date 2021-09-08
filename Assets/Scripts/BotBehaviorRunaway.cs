using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehaviorRunaway : BotBehaviorState
{
    ExpBombWork closestBomb;

    override public void Enter()
    {
        Debug.Log("Enter RUNAWAY behavior");
    }

    override public void Exit()
    {
        Debug.Log("Exit RUNAWAY behavior");
    }


    public override void Update()
    {
        Debug.Log("Update RUNAWAY behavior");

        // TODO:
        // closestBomb = ExpBombWork.FindClosestBomb(context.transform.position);
        float dist = Vector3.Distance(closestBomb.transform.position, context.transform.position);

        if (dist < 1.5f)
        {
            Vector3 dirToBomb = context.transform.position - closestBomb.transform.position;

            Vector3 newPos = context.transform.position + dirToBomb;

            context.MoveTo(newPos);
        }
        
    }


}
