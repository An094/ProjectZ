using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ApplePlayerDetectedState : EnemyPlayerDetectedState
{
    bool isPlayerInMaxAgroRange;
    E_Apple EnemyApple;

    public E_ApplePlayerDetectedState(EnemyStateMachine stateMachine, E_Apple enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerInMaxAgroRange = Enemy.CheckPlayerInMaxAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isPlayerInMaxAgroRange)
        {
            StateMachine.ChangeState(EnemyApple.IdleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
