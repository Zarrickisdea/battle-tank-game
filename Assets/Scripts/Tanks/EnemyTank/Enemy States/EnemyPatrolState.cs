using UnityEngine;

namespace EnemyTank
{
    public class EnemyPatrolState : EnemyState
    {
        public EnemyPatrolState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            enemyTankView.NavMeshAgent.isStopped = false;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            base.UpdateLogic();
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
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
}
