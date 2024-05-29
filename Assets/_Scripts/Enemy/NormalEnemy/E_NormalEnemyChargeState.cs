using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemyChargeState : EnemyChargeState
{
    E_NormalEnemy EnemyApple;
    public E_NormalEnemyChargeState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
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

        if (performCloseRangeAction)
        {
            StateMachine.ChangeState(EnemyApple.MeleeAttackState);
        }
        else if (!isDetectingLedge || isDetectingWall)
        {
            StateMachine.ChangeState(EnemyApple.LookforPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(EnemyApple.PlayerDetectedState);
            }
            else
            {
                StateMachine.ChangeState(EnemyApple.LookforPlayerState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
