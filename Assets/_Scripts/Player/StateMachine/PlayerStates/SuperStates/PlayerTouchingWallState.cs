using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchingWallState : PlayerState
{
    bool IsGround;
    bool IsTouchingLedge;
    bool IsTouchingWall;
    bool GrabInput;
    bool JumpInput;
    bool RollInput;

    public PlayerTouchingWallState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGround = Player.IsGrounded();
        IsTouchingLedge = Player.IsTouchingLedge();
        IsTouchingWall = Player.IsTouchingWall();

        if (IsTouchingWall && !IsTouchingLedge)
        {
            Player.LedgeClimbState.SetDetectedPos(Player.transform.position);
        }
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        GrabInput = Player.InputHandler.GrabInput;
        JumpInput = Player.InputHandler.JumpInput;
        RollInput = Player.InputHandler.RollInput;

        if(!IsExitingState)
        {
            if (IsGround && !GrabInput)
            {
                Player.Flip();
                StateMachine.ChangeState(Player.IdleState);
            }
            else if (!IsTouchingLedge)
            {
                StateMachine.ChangeState(Player.LedgeClimbState);
            }
            else if (JumpInput)
            {
                Player.Flip();
                //Player.SetVelocityX(2.0f * Player.FacingDirection);//TODO: 
                StateMachine.ChangeState(Player.JumpState);
            }
            else if (RollInput)
            {
                Player.Flip();
                StateMachine.ChangeState(Player.DodgeRollState);
            }
        }
        
    }
}
