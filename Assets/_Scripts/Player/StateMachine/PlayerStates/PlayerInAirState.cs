using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    private bool JumpInput;
    private bool IsGrounded;
    private bool CoyoteTime;
    private bool IsJumping;
    private bool JumpInputStop;
    public PlayerInAirState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
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

        CheckCoyoteTime();

        xInput = Player.InputHandler.NormalInputX;
        JumpInput = Player.InputHandler.JumpInput;
        JumpInputStop = Player.InputHandler.JumpInputStop;

        CheckJumpMultiplier();

        if (IsGrounded && Player.CurrentVelocity.y < 0.01f)
        {
            Player.StateMachine.ChangeState(Player.LandState);
        }

        if(JumpInput && Player.JumpState.CanJump())
        {
            Player.StateMachine.ChangeState(Player.JumpState);
        }
        else
        {
            Player.SetVelocityX(xInput * PlayerData.MovementSpeed);
            Player.CheckIfShouldFlip(xInput);
            Player.Animator.SetFloat("yVelocity", Player.CurrentVelocity.y);
        }
    }

    private void CheckJumpMultiplier()
    {
        if (IsJumping)
        {
            if (JumpInputStop)
            {
                Player.SetVelocityY(Player.CurrentVelocity.y * PlayerData.VariableJumpHeightMultiplier);
                IsJumping = false;
            }
            else if (Player.CurrentVelocity.y <= 0f)
            {
                IsJumping = false;
            }
        }
    }

    private void CheckCoyoteTime()
    {
        if(CoyoteTime && Time.time > StartTime + PlayerData.CoyoteTime)
        {
            CoyoteTime = false;
            Player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime() => CoyoteTime = true;
    public void SetIsJumping() => IsJumping = true;
}
