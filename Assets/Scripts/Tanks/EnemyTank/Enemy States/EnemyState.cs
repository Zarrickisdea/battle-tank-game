using PlayerTank;
using UnityEngine;

namespace EnemyTank
{
    public abstract class EnemyState
    {
        protected EnemyTankView enemyTankView;
        protected StateMachine enemyStateMachine;
        protected TankView playerTankView;

        public EnemyState(EnemyTankView enemyTankView, StateMachine enemyStateMachine)
        {
            this.enemyTankView = enemyTankView;
            this.enemyStateMachine = enemyStateMachine;
            playerTankView = LevelManager.Instance.PlayerTank;
        }

        public virtual void Enter()
        {

        }

        public virtual void UpdateLogic()
        {

        }

        public virtual void Exit()
        {

        }

        public virtual void UpdatePhysics()
        {

        }

        public virtual void UpdateUI()
        {
            enemyTankView.HealthValue.UpdateValue(enemyTankView.EnemyTankController.GetHealth());
            enemyTankView.HealthBar.rotation = Quaternion.Euler(0, 220, 0);
        }

        public virtual void ResolveCollision(Collision collision)
        {
            if (collision.gameObject.GetComponent<TankView>())
            {
                collision.gameObject.GetComponent<TankView>().CrashDamage();
            }
        }

        public virtual void ResolveTriggers(Collider collider)
        {
            if (collider.gameObject.GetComponent<TankView>())
            {
                enemyStateMachine.ChangeState(enemyTankView.EnemyChaseState);
            }
        }
    }
}
