using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AppleMoveState : EnemyMoveState
{
    E_Apple EnemyApple;
    public E_AppleMoveState(EnemyStateMachine stateMachine, E_Apple enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isDetectingWall || isDetectingLedge)
        {
            StateMachine.ChangeState(EnemyApple.IdleState);
        }
    }
}
