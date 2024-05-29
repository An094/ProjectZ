using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyMoveState : EnemyMoveState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyMoveState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        ArcherEnemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        if (isPlayerInMinAgroRange)
        {
            StateMachine.ChangeState(ArcherEnemy.PlayerDetectedState);
        }
        else if (isDetectingWall || isDetectingLedge)
        {
            StateMachine.ChangeState(ArcherEnemy.IdleState);
        }
    }
}
