using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeRollState : PlayerAbilityState
{
    private int xInput;
    private bool IsGrounded;
    private bool CeilingCheck;
    public PlayerDodgeRollState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        Player.SetColliderHeight(PlayerData.StandColliderHeight);
        CeilingCheck = Player.IsCeiling();

        if (CeilingCheck)
        {
            base.Enter();
            Player.SetColliderHeight(PlayerData.RollingColliderHeight);
            IsAbilityDone = false;
        }
        else
        {
            IsAbilityDone = true;
        }

    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.IsGrounded();
        CeilingCheck = Player.IsCeiling();
    }

    public override void Enter()
    {
        base.Enter();

        IsAbilityDone = false;
        xInput = Player.InputHandler.NormalInputX;
        Player.InputHandler.UseRollInput();
        Player.SetColliderHeight(PlayerData.RollingColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();

        Player.SetColliderHeight(PlayerData.StandColliderHeight);
        //Player.SetVelocityX(0);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!IsExitingState)
        {
            int RollingDirection = xInput != 0 ? xInput : Player.FacingDirection;
            if(IsGrounded)
            {
                Player.SetVelocityX(RollingDirection * PlayerData.GroundRollVelocity);
                Player.SetVelocityY(0.0f);
            }
            else
            {
                Player.SetVelocityX(RollingDirection * PlayerData.InAirRollVelocity);
                Player.SetVelocityY(-PlayerData.RollVelocityY);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public bool CanRoll()
    {
        return Time.time > StartTime + PlayerData.RollingCooldown;
        //return true;
    }
}
