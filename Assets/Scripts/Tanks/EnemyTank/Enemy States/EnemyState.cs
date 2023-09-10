using EnemyTank;
using PlayerTank;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyTankView enemyTankView;
    protected StateMachine enemyStateMachine;
    protected TankView playerTankView;

    public EnemyState (EnemyTankView enemyTankView, StateMachine enemyStateMachine)
    {
        this.enemyTankView = enemyTankView;
        this.enemyStateMachine = enemyStateMachine;
        playerTankView = TankSpawner.Instance.GetPlayerTankView();
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

    public virtual void ResolveCollision(UnityEngine.Collision collision)
    {
        if (collision.gameObject.GetComponent<TankView>())
        {
            collision.gameObject.GetComponent<TankView>().CrashDamage();
        }
    }

    public virtual void ResolveTriggers(UnityEngine.Collider collider)
    {
        if (collider.gameObject.GetComponent<TankView>())
        {
            enemyStateMachine.ChangeState(enemyTankView.EnemyChaseState);
        }
    }
}
