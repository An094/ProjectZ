using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerRollState : E_PlayerNearState
{
    int RollingDirection;
    public E_RangerRollState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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
        RollingDirection = Ranger.FacingDirection;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.RollCooldown;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!IsExiting)
        {
            Ranger.SetVelocityX(10.0f * RollingDirection);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
