using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool JumpInput;
    private bool IsGrounded;
    private bool RollInput;
    private bool PrimaryAttack;
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
        RollInput = Player.InputHandler.RollInput;
        PrimaryAttack = Player.InputHandler.PrimaryAttack;

        IsGrounded = Player.IsGrounded();

        if (JumpInput && Player.JumpState.CanJump())
        {
            Player.InputHandler.UseJumpInput();
            Player.StateMachine.ChangeState(Player.JumpState);
        }
        else if(RollInput && Player.DodgeRollState.CanRoll())
        {
            Player.StateMachine.ChangeState(Player.DodgeRollState);
        }
        else if(!IsGrounded)
        {
            Player.InAirState.StartCoyoteTime();
            Player.StateMachine.ChangeState(Player.InAirState);
        }
        else if(PrimaryAttack)
        {
            Player.InputHandler.UsePrimaryAttackInput();
            StateMachine.ChangeState(Player.PrimaryAttackState);
        }
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
