using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotBehaviorStandStill : BotBehaviorState
{
    public override void Enter()
    {
        context.agent.velocity = Vector3.zero;
        context.agent.isStopped = true;

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        
    }
}
