using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public EnemyMoveState(EnemyStateMachine stateMachine, E_Apple enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isDetectingLedge = Enemy.IsTouchingWall();
        isDetectingLedge = !Enemy.LedgeVertical();
        //isPlayerInMinAgroRange = Enemy.Play
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.SetVelocityX(EnemyData.moveSpeed * Enemy.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Enemy.SetVelocityX(EnemyData.moveSpeed * Enemy.FacingDirection);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
