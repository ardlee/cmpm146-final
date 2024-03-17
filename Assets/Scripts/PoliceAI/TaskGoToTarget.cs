using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.AI;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;

    public TaskGoToTarget(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            float distanceToPlayer = Vector3.Distance(_transform.position, target.position);

            Debug.Log($"Going to target! {distanceToPlayer} {target.position}");
            if (distanceToPlayer <= PoliceBT.fovRange)
            {
                _agent.destination = target.position;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

}
