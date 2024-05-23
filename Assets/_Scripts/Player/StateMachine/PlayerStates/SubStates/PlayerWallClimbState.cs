using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        int yInput = Player.InputHandler.NormalInputY;
        bool GrabInput = Player.InputHandler.GrabInput;

        if(yInput == 0 && GrabInput)
        {
            //Player.InputHandler.UseGrabInput();
            StateMachine.ChangeState(Player.WallGrabState);
        }
        else
        {
            Player.SetVelocityX(0f);
            if(yInput != 0)
            {
                Player.SetVelocityY(PlayerData.WallClimbVelocity * yInput);
            }
            else
            {
                StateMachine.ChangeState(Player.WallSlideState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
