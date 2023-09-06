using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyTank;

public class EnemyPatrolState : EnemyState
{
    public EnemyPatrolState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("EnemyPatrolState Enter");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Debug.Log("EnemyPatrolState Update");
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Debug.Log("EnemyPatrolState UpdatePhysics");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("EnemyPatrolState Exit");
    }
}
