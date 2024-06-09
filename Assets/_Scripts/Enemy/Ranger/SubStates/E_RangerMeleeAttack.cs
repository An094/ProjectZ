using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerMeleeAttack : E_PlayerNearState
{
    public E_RangerMeleeAttack(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        CheckIfShouldFlip = false;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        IsDone = true;
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

        if (!IsExiting)
        {
            Ranger.SetZeroVelocity();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}