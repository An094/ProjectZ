using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefendState : PlayerAbilityState
{
    bool IsDefending;
    public PlayerDefendState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
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

        Player.CombatController.IsShieldActive = true;

        IsAbilityDone = false;
    }

    public override void Exit()
    {
        Player.CombatController.IsShieldActive = false;

        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        IsDefending = Player.InputHandler.DefendInput;

        if (!IsDefending)
        {
            IsAbilityDone = true;
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
