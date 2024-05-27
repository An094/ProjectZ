using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected bool isFlipAfterIdle;
    protected bool isIdleTimeOver;

    public EnemyIdleState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        isIdleTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
        if(isFlipAfterIdle)
        {
            Enemy.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > StartTime + EnemyData.idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
