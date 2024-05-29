using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyIdleState : EnemyIdleState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyIdleState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        ArcherEnemy = enemy;
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

        if (isPlayerInMinAgroRange)
        {
            StateMachine.ChangeState(ArcherEnemy.PlayerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            StateMachine.ChangeState(ArcherEnemy.MoveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void SetFlipAfterIdle(bool value)
    {
        isFlipAfterIdle = value;
    }
}
