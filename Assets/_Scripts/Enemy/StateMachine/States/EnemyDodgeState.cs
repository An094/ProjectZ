using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyDodgeState : EnemyState
{
    protected bool isPlayerInMaxAgroRange;
    protected bool isGrounded;
    protected bool isDodgeOver;

    public EnemyDodgeState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMaxAgroRange = Enemy.CheckPlayerInMaxAgroRange();
        isGrounded = Enemy.IsGrounded();
    }

    public override void Enter()
    {
        base.Enter();

        isDodgeOver = false;

        Enemy.SetVelocity(EnemyData.DodgeSpeed, EnemyData.DodgeAngle, -Enemy.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= StartTime + EnemyData.DodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
