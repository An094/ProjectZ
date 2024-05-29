using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyLookforPlayerState : EnemyLookforPlayerState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyLookforPlayerState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        ArcherEnemy = enemy;
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
        else if (isAllTurnsTimeDone)
        {
            StateMachine.ChangeState(ArcherEnemy.MoveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
