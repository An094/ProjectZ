using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class E_EnemyWaitState : EnemyState
{
    E_EnemyBush EnemyBush;
    bool IsFirstTime;
    public E_EnemyWaitState(EnemyStateMachine stateMachine, E_EnemyBush enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyBush = enemy;
        IsFirstTime = true;
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

        //EnemyBush.Renderer.enabled = false;
        //EnemyBush.Collider.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();

        //EnemyBush.Renderer.enabled = true;
        //EnemyBush.Collider.enabled = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= StartTime + EnemyData.idleTime)
        {
            if(!IsFirstTime)
            {
                Transform temp = EnemyBush.PatrolStartPosition;
                EnemyBush.PatrolStartPosition = EnemyBush.PatrolFinishPosiion;
                EnemyBush.PatrolFinishPosiion = temp;

                Enemy.Flip();
            }
            else
            {
                IsFirstTime = false;
            }

            StateMachine.ChangeState(EnemyBush.RiseState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
