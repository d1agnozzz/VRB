using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehaviorAttack : BotBehaviorState
{
    override public void Enter()
    {
        Debug.Log("Enter ATTACK behavior");
    }

    override public void Exit()
    {
        Debug.Log("Exit ATTACK behavior");
    }


    public override void Update()
    {
        Debug.Log("Update ATTACK behavior");
    }
}