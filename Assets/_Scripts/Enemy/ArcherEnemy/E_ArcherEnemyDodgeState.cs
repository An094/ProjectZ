using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyDodgeState : EnemyDodgeState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyDodgeState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        ArcherEnemy = enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
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

        if(isDodgeOver)
        {
            if (isPlayerInMaxAgroRange)
            {
                StateMachine.ChangeState(ArcherEnemy.RangedAttackState);
            }
            else
            {
                StateMachine.ChangeState(ArcherEnemy.LookforPlayerState);
            }
        }
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
