using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    E_NormalEnemy EnemyApple;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isDetectingLedge;

    public EnemyPlayerDetectedState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        performCloseRangeAction = false;
        Enemy.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Enemy.SetVelocityX(0f);

        if(Time.time >= StartTime + EnemyData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMaxAgroRange = Enemy.CheckPlayerInMaxAgroRange();
        isPlayerInMaxAgroRange = Enemy.CheckPlayerInMaxAgroRange();
        isDetectingLedge = Enemy.LedgeVertical();
        performCloseRangeAction = Enemy.CheckPlayerInCloseRangeAction();
    }
}
