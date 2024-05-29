using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemyPlayerDetectedState : EnemyPlayerDetectedState
{
    E_NormalEnemy EnemyApple;

    public E_NormalEnemyPlayerDetectedState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerInMaxAgroRange = Enemy.CheckPlayerInMaxAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            StateMachine.ChangeState(EnemyApple.MeleeAttackState);
        }
        else if (performLongRangeAction)
        {
            StateMachine.ChangeState(EnemyApple.ChargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            StateMachine.ChangeState(EnemyApple.LookforPlayerState);
        }
        else if (!isDetectingLedge)
        {
            EnemyApple.Flip();
            StateMachine.ChangeState(EnemyApple.MoveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
