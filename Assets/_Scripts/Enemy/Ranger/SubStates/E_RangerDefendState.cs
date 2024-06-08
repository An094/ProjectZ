using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerDefendState : E_PlayerNearState
{
    public E_RangerDefendState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        CheckIfShouldFlip = true;
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

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.DefendCooldown;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!IsExiting)
        {
            Ranger.SetZeroVelocity();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
