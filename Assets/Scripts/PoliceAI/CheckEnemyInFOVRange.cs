using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << 7;

    private Transform _transform;
    private Animator _animator;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, PoliceBT.fovRange, _enemyLayerMask);

            if (colliders.Length > 0)
            {
                Debug.Log(colliders[0].name);
                parent.parent.SetData("target", colliders[0].transform);
                //_animator.SetBool("Walking", true);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
    private void OnDrawGizmos()
    {
        object t = GetData("target");
        if (t != null) {

        Gizmos.DrawWireSphere(_transform.position, PoliceBT.fovRange);

        }
    }
}
