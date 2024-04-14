using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
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

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Player.CheckIfShouldFlip(xInput);

        if(xInput == 0)
        {
            Player.StateMachine.ChangeState(Player.IdleState);
        }
        else
        {
            Player.SetVelocityX(PlayerData.MovementSpeed * xInput);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
