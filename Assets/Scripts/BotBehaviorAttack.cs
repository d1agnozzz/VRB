using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehaviorAttack : BotBehaviorState
{
    private HashSet<Bomberman> bombersArround;
    private Bomberman closestBomber;




    override public void Enter()
    {
        Debug.Log("Enter ATTACK behavior for " + context.name);
    }

    override public void Exit()
    {
        Debug.Log("Exit ATTACK behavior for " + context.name);
    }


    public override void Update()
    {
        //Debug.Log("Update ATTACK behavior");


        if (ExpBombWork.IsThereBombs() && (ExpBombWork.FindClosestBomb(context.transform.position).transform.position - context.transform.position).sqrMagnitude <= bombTriggerRange * bombTriggerRange)
        {   
            //context.SetBehavior(new BotBehaviorRunaway());
        }


        

        if (!Bomberman.IsThereBombers()) 
        { 
            context.SetBehavior(new BotBehaviorSearch()); 
        }

        closestBomber = Bomberman.FindClosestBomber(context.transform.position);

        if ((context.transform.position - closestBomber.transform.position).sqrMagnitude < bomberTriggerRange * bomberTriggerRange)
        {
            context.MoveTo(closestBomber.transform.position);
            if ((context.transform.position - closestBomber.transform.position).sqrMagnitude < 1)
            {
                context.bomberman.PlantBomb();
                //Debug.Log("Trying INSTANTIATE a bomb");
            }
        }

        else
        {
            context.SetBehavior(new BotBehaviorSearch());
        }


    }
}