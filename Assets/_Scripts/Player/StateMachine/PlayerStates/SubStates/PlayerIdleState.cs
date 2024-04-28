using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public float yInput;
    public PlayerIdleState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Player.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        yInput = Player.InputHandler.NormalInputY;

        if(xInput != 0)
        {
            StateMachine.ChangeState(Player.MoveState);
        }
        else if(xInput == 0 && yInput == -1)
        {
            StateMachine.ChangeState(Player.CrouchIdleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
