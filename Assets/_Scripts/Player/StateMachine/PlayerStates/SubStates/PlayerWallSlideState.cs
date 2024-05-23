using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    bool GrabInput;
    int xInput;

    public PlayerWallSlideState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        GrabInput = Player.InputHandler.GrabInput;
        xInput = Player.InputHandler.NormalInputX;

        if (GrabInput)
        {
            //Player.InputHandler.UseGrabInput();
            StateMachine.ChangeState(Player.WallGrabState);
        }
        else if(xInput != 0 && xInput != Player.FacingDirection)
        {
            StateMachine.ChangeState(Player.InAirState);
        }
        else
        {
            Player.SetVelocityY(PlayerData.WallSlideVelocity * -1);
            Player.SetVelocityX(0.0f);
        }

    }
}
