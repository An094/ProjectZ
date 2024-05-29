using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine StateMachine;
    protected Enemy Enemy;
    private string AnimName;
    protected EnemyData EnemyData;
    protected bool isAnimationFinished;

    protected float StartTime;

    public EnemyState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData)
    {
        this.StateMachine = stateMachine;
        this.Enemy = enemy;
        this.AnimName = animName;
        this.EnemyData = enemyData;
    }

    public virtual void Enter()
    {
        DoCheck();
        StartTime = Time.time;
        isAnimationFinished = false;
        Enemy.Animator.SetBool(AnimName, true);
    }

    public virtual void Exit()
    {
        Enemy.Animator.SetBool(AnimName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {

    }
    public virtual void AnimationTrigger()
    {
    }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
    }
}
