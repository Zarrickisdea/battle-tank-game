using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyTank;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("EnemyAttackState Enter");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Debug.Log("EnemyAttackState Update");
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Debug.Log("EnemyAttackState UpdatePhysics");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("EnemyAttackState Exit");
    }
}