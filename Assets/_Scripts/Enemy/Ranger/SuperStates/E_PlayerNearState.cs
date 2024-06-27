using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayerNearState : EnemyState
{
    protected E_Ranger Ranger;
    protected bool IsDone;
    protected float LastTimeFinish;
    protected bool IsGrounded;

    protected bool IsExiting;

    protected bool CheckIfShouldFlip;

    protected bool IsAllowCheckFlip;
    public E_PlayerNearState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        Ranger = enemy;
        LastTimeFinish = Time.time;
        IsAllowCheckFlip = true;
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

        IsGrounded = Enemy.IsGrounded();
    }

    public override void Enter()
    {
        base.Enter();

        IsDone = false;
        IsExiting = false;

        if(IsAllowCheckFlip)
        {
            Ranger.CheckIfShouldFlip();
        }
    }

    public override void Exit()
    {
        base.Exit();

        IsExiting = true;
        LastTimeFinish = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(IsDone)
        {
            if(IsGrounded)
            {
                StateMachine.ChangeState(Ranger.playerDetectedState);
            }
            else
            {
                StateMachine.ChangeState(Ranger.inAirState);
            }
        }
        else if (CheckIfShouldFlip)
        {
            Ranger.CheckIfShouldFlip();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public virtual bool IsOnCooldown()
    {
        return false;
    }
}
