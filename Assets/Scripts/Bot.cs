using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    private BotBehaviorState behaviorCurrent;
    private float plantingCooldown = 3f;
    [HideInInspector] public NavMeshAgent agent;

    [HideInInspector] public Bomberman bomberman;
    public float wanderRadius;

    public static float bombTriggerRange = 1.5f;
    public static float bomberTriggerRange = 1.5f;
    

    private void Start()
    {
        bomberman = GetComponent<Bomberman>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        SetBehavior(new BotBehaviorSearch());
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ExpBombWork>() != null)
        {
            Debug.Log("Enter collider " + other.name);
            SetBehavior(new BotBehaviorRunaway());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ExpBombWork>() != null)
        {
            Debug.Log("Exit collider " + other.name);
            SetBehavior(new BotBehaviorSearch());
        }
    }

    private void Update()
    {
        Ray ray = new Ray(this.transform.position + new Vector3(0f, 0.5f, 0f), this.transform.forward.normalized);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 0.95f))
        {
            if (hitData.collider.GetComponent<DWKill>() != null && plantingCooldown >=1)
            {
                bomberman.PlantBomb();
                plantingCooldown = 0f;
            }
        }

        plantingCooldown += Time.deltaTime;

        if (behaviorCurrent != null)
            behaviorCurrent.Update();
    }

    private void LateUpdate()
    {
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
    }

    private void OnDrawGizmos()
    { 
        Gizmos.DrawRay(this.transform.position + new Vector3(0f, 0.5f, 0f), this.transform.forward.normalized);
        //Gizmos.DrawWireSphere(transform.position, bombTriggerRange);

    }



    public void SetBehavior(BotBehaviorState newBehavior)
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
