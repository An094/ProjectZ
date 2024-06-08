using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerLandState : EnemyState
{
    E_Ranger Ranger;
    public E_RangerLandState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
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

        if (isAnimationFinished)
        {
            StateMachine.ChangeState(Ranger.playerDetectedState);
            
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
