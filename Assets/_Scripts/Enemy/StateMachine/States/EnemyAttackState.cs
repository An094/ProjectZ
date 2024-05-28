using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform AttackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;

    public EnemyAttackState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData, Transform attackPostion) : base(stateMachine, enemy, animName, enemyData)
    {
        AttackPosition = attackPostion;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinAgroRange = Enemy.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.AttackState = this;
        isAnimationFinished = false;
        Enemy.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Enemy.SetVelocityX(0f);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public virtual void TriggerAttack()
    {
       
    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
