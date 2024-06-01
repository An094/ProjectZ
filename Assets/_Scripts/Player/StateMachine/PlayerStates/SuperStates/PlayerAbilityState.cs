using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool IsAbilityDone;
    private bool IsGrounded;
    private bool PrimaryAttackInput;

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

        PrimaryAttackInput = Player.InputHandler.PrimaryAttack;

        if (IsAbilityDone)
        {
            if(IsGrounded && Player.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(Player.IdleState);
            }
            else if(PrimaryAttackInput)
            {
                Player.InputHandler.UsePrimaryAttackInput();
                StateMachine.ChangeState(Player.PrimaryAttackState);
            }
            else
            {
                StateMachine.ChangeState(Player.InAirState);
            }
        }
    }
}
