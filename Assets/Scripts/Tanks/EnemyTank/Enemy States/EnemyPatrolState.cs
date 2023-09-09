using EnemyTank;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    public EnemyPatrolState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
    {
    }

    public override void Enter()
    {
        enemyTankView.NavMeshAgent.isStopped = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        enemyTankView.EnemyTankController.StartPatrol();
    }

    public override void ResolveTriggers(Collider collider)
    {
        base.ResolveTriggers(collider);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
