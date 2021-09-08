using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class NavMeshDebugger : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agentToDebug;

    private LineRenderer linerenderer;

    private void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (agentToDebug.hasPath)
        {
            linerenderer.positionCount = agentToDebug.path.corners.Length;
            linerenderer.SetPositions(agentToDebug.path.corners);
            linerenderer.enabled = true;
        }
        else
        {
            linerenderer.enabled = false;
        }
    }
}
