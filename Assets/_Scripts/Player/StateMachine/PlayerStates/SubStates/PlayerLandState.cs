using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public bool NextTimeIsStrong;
    public PlayerLandState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
        NextTimeIsStrong = false;
    }

    public override void Enter()
    {
        base.Enter();

        if(NextTimeIsStrong)
        {
            GameManager.Instance.PlaySFX("Land2");
        }
        else
        {
            GameManager.Instance.PlaySFX("Land");
        }

        NextTimeIsStrong = false;
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
        else
        {
            Player.SetVelocityZero();
        }
    }
}
