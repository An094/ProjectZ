using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerInAirState : EnemyState
{
    E_Ranger Ranger;
    private bool IsGrounded;
    public E_RangerInAirState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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

        IsGrounded = Ranger.IsGrounded();
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

        if(!Ranger.shootInAirState.IsOnCooldown() && Ranger.CurrentVelocity.y < 0.01f)
        {
            StateMachine.ChangeState(Ranger.shootInAirState);
        }
        else if(IsGrounded)
        {
            StateMachine.ChangeState(Ranger.landState);
        }
        else
        {
            Ranger.Animator.SetFloat("yVelocity", Ranger.CurrentVelocity.y);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
