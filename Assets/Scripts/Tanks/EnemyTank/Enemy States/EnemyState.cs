using EnemyTank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyTankView enemyTankView;
    protected StateMachine enemyStateMachine;

    public EnemyState (EnemyTankView enemyTankView, StateMachine enemyStateMachine)
    {
        this.enemyTankView = enemyTankView;
        this.enemyStateMachine = enemyStateMachine;
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
}
