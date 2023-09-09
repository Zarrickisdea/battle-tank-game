using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyTank;

public class EnemyChaseState : EnemyState
{
    private float chaseTime;
    public EnemyChaseState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        chaseTime = 0f;
    }

    public override void UpdateLogic()
    {
        chaseTime += Time.deltaTime;
        if (chaseTime >= 5f)
        {
            enemyStateMachine.ChangeState(enemyTankView.EnemyAttackState);
        }
    }

    public override void UpdatePhysics()
    {
        enemyTankView.EnemyTankController.StartChase(playerTankView.transform);
    }

    public override void Exit()
    {
        chaseTime = 0f;
    }
}