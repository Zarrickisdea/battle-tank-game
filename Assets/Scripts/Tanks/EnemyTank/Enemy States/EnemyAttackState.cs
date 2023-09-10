using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyTank;

public class EnemyAttackState : EnemyState
{
    private float attackTime;
    public EnemyAttackState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        enemyTankView.NavMeshAgent.isStopped = true;
        attackTime = 0f;
    }

    public override void UpdateLogic()
    {
        attackTime += Time.deltaTime;
        if (attackTime >= 1f)
        {
            enemyTankView.EnemyTankController.Fire();
            enemyStateMachine.ChangeState(enemyTankView.EnemyPatrolState);
        }
    }

    public override void UpdatePhysics()
    {
        if (playerTankView != null)
        {
            enemyTankView.EnemyTankController.RotateTurret(playerTankView.transform.position);
        }
    }

    public override void Exit()
    {
        enemyTankView.NavMeshAgent.isStopped = false;
    }
}