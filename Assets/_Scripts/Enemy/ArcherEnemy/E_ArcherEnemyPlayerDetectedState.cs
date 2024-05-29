using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyPlayerDetectedState : EnemyPlayerDetectedState
{
    E_ArcherEnemy ArcherEnemy;
    public E_ArcherEnemyPlayerDetectedState(EnemyStateMachine stateMachine, E_ArcherEnemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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

        if(performLongRangeAction)
        {
            StateMachine.ChangeState(ArcherEnemy.RangedAttackState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            StateMachine.ChangeState(ArcherEnemy.LookforPlayerState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
