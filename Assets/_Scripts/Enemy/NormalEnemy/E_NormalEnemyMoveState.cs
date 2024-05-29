using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemyMoveState : EnemyMoveState
{
    E_NormalEnemy EnemyApple;
    public E_NormalEnemyMoveState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        if(isPlayerInMinAgroRange)
        {
            StateMachine.ChangeState(EnemyApple.PlayerDetectedState);
        }    
        else if(isDetectingWall || isDetectingLedge)
        {
            StateMachine.ChangeState(EnemyApple.IdleState);
        }
    }
}
