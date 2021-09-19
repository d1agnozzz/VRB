using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotBehaviorSearch : BotBehaviorState
{
    

    private bool isWandering;
    private Vector3 destinationCurrent;
    private float wanderingTimer = 3f;

    
    

    #region ENTER
    override public void Enter()
    {
        Debug.Log("Enter SEARCH behavior");
        isWandering = false;
    }
    #endregion

    #region EXIT
    public override void Exit()
    {
        Debug.Log("Exit SEARCH behavior");
    }
    #endregion

    // возвращает случайную точку с навмэша 
    



    override public void Update()
    {

        wanderingTimer -= Time.deltaTime;

        //Debug.Log("Update SEARCH behavior for " + context.name);

        

        //if (ExpBombWork.IsThereBombs()) {
        //    ExpBombWork closestBomb = ExpBombWork.FindClosestBomb(context.transform.position);
        //    if ((closestBomb.transform.position - context.transform.position).sqrMagnitude < bombTriggerRange * bombTriggerRange)
        //    {
        //        Ray ray = new Ray(context.transform.position, context.transform.forward);
        //        RaycastHit bombInSight;
        //        if (Physics.Raycast(ray, out bombInSight))
        //        {
        //            if (bombInSight.collider.GetComponent<ExpBombWork>())
        //            {
        //                //context.SetBehavior(new BotBehaviorRunaway());

        //            }
        //        }
        //    }
  
        //}


        if (Bomberman.IsThereBombers() && (Bomberman.FindClosestBomber(context.transform.position).transform.position-context.transform.position).sqrMagnitude <= bomberTriggerRange * bomberTriggerRange)
        {
            context.SetBehavior(new BotBehaviorAttack());
        }

        if (isWandering == false)
        {
            NavMeshQueryFilter mask = new NavMeshQueryFilter();
            mask.areaMask = (1 << NavMesh.GetAreaFromName("Walkable"));




            Vector3 destinationNew = RandomNavSphere(context.transform.position, context.wanderRadius, mask.areaMask);
            context.MoveTo(destinationNew);
            destinationCurrent = destinationNew;
            isWandering = true;

        }
        if (Vector3.Distance(context.transform.position, destinationCurrent) < 0.1 || wanderingTimer <= 0)
        {
            isWandering = false;
            wanderingTimer = 3f;
        }
    }
}
