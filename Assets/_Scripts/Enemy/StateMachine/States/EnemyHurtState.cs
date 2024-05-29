using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyState
{
    protected bool IsGrounded;
    protected bool IsStunTimerOver;
    protected bool IsFacingPlayerWhileHurt;
    protected int FacingDirectionWhileHurt;
    public EnemyHurtState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        IsGrounded = Enemy.IsGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        IsStunTimerOver = false;
        IsFacingPlayerWhileHurt = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > StartTime + EnemyData.StunTime)
        {
            IsStunTimerOver = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void SetFacingDirectionWhileHurt(int direction)
    {
        FacingDirectionWhileHurt = direction;
    }


}
