using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyTank;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("EnemyChaseState Enter");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Debug.Log("EnemyChaseState Update");
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Debug.Log("EnemyChaseState UpdatePhysics");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("EnemyChaseState Exit");
    }
}