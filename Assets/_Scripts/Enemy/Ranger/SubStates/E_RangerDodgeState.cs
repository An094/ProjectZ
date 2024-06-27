using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerDodgeState : E_PlayerNearState
{
    public E_RangerDodgeState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        CheckIfShouldFlip = false;
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
        IsAllowCheckFlip = false;
        base.Enter();

        Ranger.SetVelocityX(Ranger.FacingDirection * 10.0f);
        Ranger.SetVelocityY(12.0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.DodgeCooldown;
        //return false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //if (IsDone)
        //{
        //    if (!Ranger.shootInAirState.IsOnCooldown())
        //    {
        //        StateMachine.ChangeState(Ranger.shootInAirState);
        //    }
        //    else
        //    {
        //        StateMachine.ChangeState(Ranger.inAirState);
        //    }
        //}
        
        if(Ranger.CurrentVelocity.y < 1f)
        {
            IsDone = true;
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
