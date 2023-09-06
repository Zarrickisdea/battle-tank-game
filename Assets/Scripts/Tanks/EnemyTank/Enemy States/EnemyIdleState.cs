using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyTank;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("EnemyIdleState Enter");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Debug.Log("EnemyIdleState Update");
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Debug.Log("EnemyIdleState UpdatePhysics");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("EnemyIdleState Exit");
    }
}