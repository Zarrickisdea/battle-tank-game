using UnityEngine;

namespace EnemyTank
{
    public class EnemyChaseState : EnemyState
    {
        private float chaseTime;
        public EnemyChaseState(EnemyTankView enemyTankView, StateMachine stateMachine) : base(enemyTankView, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            chaseTime = 0f;
        }

        public override void UpdateLogic()
        {
            chaseTime += Time.deltaTime;
            if (chaseTime >= 3f)
            {
                enemyStateMachine.ChangeState(enemyTankView.EnemyAttackState);
            }
        }

        public override void UpdatePhysics()
        {
            if (playerTankView != null)
            {
                enemyTankView.EnemyTankController.StartChase(playerTankView.transform);
            }
        }

        public override void Exit()
        {
            base.Exit();
            chaseTime = 0f;
        }
    }
}