using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    Vector2 CachedPosition;
    public PlayerWallGrabState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
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

        CachedPosition = Player.transform.position;
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

        if(!GrabInput /* || yInput < 0*/)
        {
            //Player.InputHandler.UseGrabInput();
            StateMachine.ChangeState(Player.WallSlideState);
        }
        else if(yInput != 0)
        {
            StateMachine.ChangeState(Player.WallClimbState);
        }
        else
        {
            Player.SetVelocityZero();
            Player.transform.position = CachedPosition;//TODO: if rm this line, player will slide
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
