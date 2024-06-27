using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    private int yInput;
    private bool JumpInput;
    private bool RollInput;
    private bool IsGrounded;
    private bool CoyoteTime;
    private bool IsJumping;
    private bool JumpInputStop;
    private bool IsTouchingWall;
    private bool IsTouchingLedge;
    private bool IsOverPlatformer;
    private bool PrimaryAttack;

    public PlayerInAirState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.IsGrounded();
        IsTouchingWall = Player.IsTouchingWall();
        IsTouchingLedge = Player.IsTouchingLedge();
        IsOverPlatformer = Player.IsOverPlatformer();

        if(IsTouchingWall && !IsTouchingLedge)
        {
            Player.LedgeClimbState.SetDetectedPos(Player.transform.position);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();

        xInput = Player.InputHandler.NormalInputX;
        yInput = Player.InputHandler.NormalInputY;
        JumpInput = Player.InputHandler.JumpInput;
        RollInput = Player.InputHandler.RollInput;
        PrimaryAttack = Player.InputHandler.PrimaryAttack;
        JumpInputStop = Player.InputHandler.JumpInputStop;

        CheckJumpMultiplier();

        if (IsGrounded && Player.CurrentVelocity.y < 0.01f)
        {
            StateMachine.ChangeState(Player.LandState);
        }
        else if(JumpInput && Player.JumpState.CanJump() && Player.CurrentVelocity.y < 0f)
        {
            StateMachine.ChangeState(Player.JumpState);
        }
        else if(RollInput && Player.DodgeRollState.CanRoll())
        {
            StateMachine.ChangeState(Player.DodgeRollState);
        }
        else if (IsTouchingWall && !IsTouchingLedge && !IsGrounded)
        {
            StateMachine.ChangeState(Player.LedgeClimbState);
        }
        else if(IsTouchingWall && (xInput == Player.FacingDirection || xInput == 0) && Player.CurrentVelocity.y < 0.0f)
        {
            StateMachine.ChangeState(Player.WallSlideState);
        }
        else if(PrimaryAttack)
        {
            Player.InputHandler.UsePrimaryAttackInput();
            StateMachine.ChangeState(Player.PrimaryAttackState);
        }
        else if(yInput == -1 && JumpInput)
        {
            Player.SetVelocityX(0);
            Player.SetVelocityY(-30f);
            Player.Animator.SetFloat("yVelocity", Player.CurrentVelocity.y);
            Player.LandState.NextTimeIsStrong = true;
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

    public override void Enter()
    {
        base.Enter();

        Player.Trail.enabled = true;
    }

    public override void Exit()
    {
        base.Exit();

        Player.Trail.enabled = false;
    }
}
