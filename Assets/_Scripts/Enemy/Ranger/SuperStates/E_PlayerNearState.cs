using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayerNearState : EnemyState
{
    E_Ranger Ranger;
    protected bool IsDone;
    protected float LastTimeFinish;
    protected bool IsGrounded;

    protected bool IsExiting;
    public E_PlayerNearState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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

        IsGrounded = Enemy.IsGrounded();
    }

    public override void Enter()
    {
        base.Enter();

        IsDone = false;
        IsExiting = false;
    }

    public override void Exit()
    {
        base.Exit();

        IsExiting = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsDone && IsGrounded)
        {
            StateMachine.ChangeState(Ranger.playerDetectedState);
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
