using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(IsAnimationFinished)
        {
            if (xInput != 0)
            {
                Player.StateMachine.ChangeState(Player.MoveState);
            }
            else
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}
