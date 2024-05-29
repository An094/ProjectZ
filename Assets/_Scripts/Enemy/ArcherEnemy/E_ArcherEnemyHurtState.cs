using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyHurtState : EnemyHurtState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyHurtState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        ArcherEnemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        if (IsFacingPlayerWhileHurt && FacingDirectionWhileHurt != Enemy.FacingDirection)
        {
            ArcherEnemy.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsGrounded && IsStunTimerOver)
        {
            //normalEnemy.IdleState.SetFlipAfterIdle(false);
            StateMachine.ChangeState(ArcherEnemy.PlayerDetectedState);
        }
    }
}
