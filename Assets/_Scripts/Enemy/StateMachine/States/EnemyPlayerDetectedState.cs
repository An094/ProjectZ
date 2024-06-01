using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{ 
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isDetectingLedge;

    public EnemyPlayerDetectedState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
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

        performCloseRangeAction = false;
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
