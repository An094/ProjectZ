using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
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
            GameObject.Destroy(Enemy.gameObject);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
