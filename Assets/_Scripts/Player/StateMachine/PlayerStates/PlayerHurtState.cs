using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void AniamtionTrigger()
    {
        base.AniamtionTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if(Time.time > StartTime + 0.3f)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
        else
        {
            Player.SetVelocityZero();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
