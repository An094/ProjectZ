using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerState
{
    private int xInput, yInput;
    public PlayerCrouchIdleState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.SetVelocityZero();
        Player.SetColliderHeight(PlayerData.CrouchColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();
        Player.SetColliderHeight(PlayerData.StandColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = Player.InputHandler.NormalInputX;
        yInput = Player.InputHandler.NormalInputY;

        if(xInput == 0 && yInput != -1)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
        else if(xInput != 0 && yInput != -1)
        {
            StateMachine.ChangeState(Player.MoveState);
        }
    }
}
