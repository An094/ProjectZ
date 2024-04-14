using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool IsAbilityDone;
    private bool IsGrounded;

    public PlayerAbilityState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.IsGrounded();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsAbilityDone)
        {
            if(IsGrounded && Player.CurrentVelocity.y < 0.01f)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
            else
            {
                Player.StateMachine.ChangeState(Player.InAirState);
            }
        }
    }
}
