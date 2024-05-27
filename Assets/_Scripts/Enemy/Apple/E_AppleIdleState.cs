using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AppleIdleState : EnemyIdleState
{
    E_Apple EnemyApple;
    public E_AppleIdleState(EnemyStateMachine stateMachine, E_Apple enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
        isFlipAfterIdle = true;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isIdleTimeOver)
        {
            StateMachine.ChangeState(EnemyApple.MoveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
