using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool JumpInput;
    private bool IsGrounded;
    public PlayerGroundedState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.IsGrounded();
    }

    public override void Enter()
    {
        base.Enter();

        Player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = Player.InputHandler.NormalInputX;
        JumpInput = Player.InputHandler.JumpInput;
        IsGrounded = Player.IsGrounded();

        if (JumpInput && Player.JumpState.CanJump())
        {
            Player.InputHandler.UseJumpInput();
            Player.StateMachine.ChangeState(Player.JumpState);
        }
        else if(!IsGrounded)
        {
            Player.InAirState.StartCoyoteTime();
            Player.StateMachine.ChangeState(Player.InAirState);
        }
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}