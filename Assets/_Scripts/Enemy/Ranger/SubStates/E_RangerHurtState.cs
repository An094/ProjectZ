using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerHurtState : EnemyState
{
    E_Ranger Ranger;
    public float CurrentStunResistance;
    public float MaxRangerResistance;
    public E_RangerHurtState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        Ranger = enemy;
        MaxRangerResistance = enemyData.StunResistance;
        CurrentStunResistance = MaxRangerResistance;
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

        ResetResistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > StartTime + 0.3f)
        {
            StateMachine.ChangeState(Ranger.playerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void ResetResistance()
    {
        CurrentStunResistance = MaxRangerResistance;
    }

    public bool CanStun()
    {
        return CurrentStunResistance <= 0f;
    }

    public void DecreaseSR(float amount)
    {
        CurrentStunResistance -= amount;
    }
}
