using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_EnemyBushRiseUpState : EnemyState
{
    E_EnemyBush EnemyBush;
    public E_EnemyBushRiseUpState(EnemyStateMachine stateMachine, E_EnemyBush enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyBush = enemy;
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
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished)
        {
            StateMachine.ChangeState(EnemyBush.MoveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
