using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemyHurtState : EnemyHurtState
{
    E_NormalEnemy normalEnemy;
    public E_NormalEnemyHurtState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        normalEnemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        if(IsFacingPlayerWhileHurt && FacingDirectionWhileHurt != Enemy.FacingDirection)
        {
            normalEnemy.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(IsGrounded && IsStunTimerOver)
        {
            //normalEnemy.IdleState.SetFlipAfterIdle(false);
            StateMachine.ChangeState(normalEnemy.PlayerDetectedState);
        }
    }
}
