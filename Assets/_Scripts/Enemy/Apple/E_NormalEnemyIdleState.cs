using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemyIdleState : EnemyIdleState
{
    E_NormalEnemy EnemyApple;
    public E_NormalEnemyIdleState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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

        if(isPlayerInMinAgroRange)
        {
            StateMachine.ChangeState(EnemyApple.PlayerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            StateMachine.ChangeState(EnemyApple.MoveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
