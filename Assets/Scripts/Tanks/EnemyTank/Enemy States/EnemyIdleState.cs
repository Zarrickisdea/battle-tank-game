using UnityEngine;
using EnemyTank;

public class EnemyIdleState : EnemyState
{
    private float idleTime;
    public EnemyIdleState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        idleTime = 0f;
        enemyTankView.NavMeshAgent.isStopped = true;
    }

    public override void UpdateLogic()
    {
        idleTime += Time.deltaTime;
        if (idleTime >= 2f)
        {
            enemyStateMachine.ChangeState(enemyTankView.EnemyPatrolState);
        }
    }

    public override void ResolveTriggers(Collider collider)
    {
        base.ResolveTriggers(collider);
    }

    public override void Exit()
    {
        idleTime = 0f;
    }
}