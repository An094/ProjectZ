using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerPlayerDetectedState : EnemyState
{
    E_Ranger Ranger;
    private bool IsPlayerClose;
    private bool IsFacingWall;
    public E_RangerPlayerDetectedState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        Ranger = enemy;
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

        IsPlayerClose = Ranger.IsPlayerClose();
        IsFacingWall = Ranger.IsTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();

        Ranger.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsFacingWall && IsPlayerClose)
        {
            Ranger.Flip();
            StateMachine.ChangeState(Ranger.dodgeState);
        }
        else if(IsPlayerClose)
        {
            if(!Ranger.dodgeState.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.dodgeState);
            }
            else if(!Ranger.rollState.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.rollState);
            }
            else if(!Ranger.slideState.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.slideState);
            }
            else if(!Ranger.meleeAttack.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.meleeAttack);
            }
            else
            {
                StateMachine.ChangeState(Ranger.defendState);
            }
        }
        else
        {
            if(!Ranger.fallingStarState.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.fallingStarState);
            }
            else if(!Ranger.beamAttack.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.beamAttack);
            }
            else
            {
                StateMachine.ChangeState(Ranger.rangedAttack);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
