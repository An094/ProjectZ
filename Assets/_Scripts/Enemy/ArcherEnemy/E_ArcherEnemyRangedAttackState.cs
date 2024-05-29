using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyRangedAttackState : EnemyRangedAttackState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyRangedAttackState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData, Transform attackPostion) : base(stateMachine, enemy, animName, enemyData, attackPostion)
    {
        ArcherEnemy = enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(ArcherEnemy.PlayerDetectedState);
            }
            else
            {
                StateMachine.ChangeState(ArcherEnemy.LookforPlayerState);
            }
        }
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
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
