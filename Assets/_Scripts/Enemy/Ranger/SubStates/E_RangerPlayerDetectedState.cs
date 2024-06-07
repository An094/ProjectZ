using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerPlayerDetectedState : EnemyState
{
    E_Ranger Ranger;
    private bool IsPlayerClose;
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

        if(IsPlayerClose)
        {
            if(!Ranger.dodgeNShootState.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.dodgeNShootState);
            }
            else if(!Ranger.dodgeState.IsOnCooldown())
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
            else if(!Ranger.defendState.IsOnCooldown())
            {
                StateMachine.ChangeState(Ranger.defendState);
            }
            else
            {
                StateMachine.ChangeState(Ranger.meleeAttack);
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
