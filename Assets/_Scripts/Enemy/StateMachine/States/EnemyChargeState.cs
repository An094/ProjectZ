using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public EnemyChargeState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinAgroRange = Enemy.CheckPlayerInMinAgroRange();
        isDetectingLedge = Enemy.LedgeVertical();
        isDetectingWall = Enemy.IsTouchingWall();

        performCloseRangeAction = Enemy.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        Enemy.SetVelocityX(EnemyData.ChargeSpeed * Enemy.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Enemy.SetVelocityX(EnemyData.ChargeSpeed * Enemy.FacingDirection);

        if(Time.time >= StartTime + EnemyData.ChargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
