using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerState
{
    public PlayerDieState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //if(IsAnimationFinished)
        //{
        //    ///Player.gameObject.SetActive(false);
        //}
        //else
        //{
        //    Player.SetVelocityZero();
        //}
        Player.SetVelocityZero();
    }
}
