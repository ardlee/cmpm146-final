using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public AgentLineRenderer pathLine;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(movePosition, out var hitInfo)) {
                agent.SetDestination(hitInfo.point);
            }
        }
        // Draw the new path as we move along it.
        pathLine.DrawPath(agent.path);
    }
}
