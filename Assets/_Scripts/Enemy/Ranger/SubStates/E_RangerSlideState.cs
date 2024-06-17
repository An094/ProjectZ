using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerSlideState : E_PlayerNearState
{
    private int SlideDirection;
    bool WallInfront;
    public E_RangerSlideState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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

        WallInfront = Ranger.WallInfront();
    }

    public override void Enter()
    {
        base.Enter();

        SlideDirection = Ranger.FacingDirection;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.SlideCooldown;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExiting)
        {
            if(!WallInfront)
            {
                Ranger.SetVelocityX(9.0f * SlideDirection);
            }
            else
            {
                StateMachine.ChangeState(Ranger.playerDetectedState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
