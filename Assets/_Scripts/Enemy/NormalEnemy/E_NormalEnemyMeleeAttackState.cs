using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemyMeleeAttackState : EnemyMeleeAttackState
{
    E_NormalEnemy EnemyApple;
    public E_NormalEnemyMeleeAttackState(EnemyStateMachine stateMachine, E_NormalEnemy enemy, string animName, EnemyData enemyData, Transform attackPostion) : base(stateMachine, enemy, animName, enemyData, attackPostion)
    {
        EnemyApple = enemy;
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished)
        {
            if(isPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(EnemyApple.PlayerDetectedState);
            }
            else
            {
                StateMachine.ChangeState(EnemyApple.LookforPlayerState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
