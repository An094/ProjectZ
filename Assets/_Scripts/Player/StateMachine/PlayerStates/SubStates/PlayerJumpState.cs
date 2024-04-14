using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
   
    private int AmoutOfJumpsLeft;
    public PlayerJumpState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
        AmoutOfJumpsLeft = PlayerData.AmountOfJumps;
    }
    public override void Enter()
    {
        base.Enter();

        Player.SetVelocityY(PlayerData.JumpSpeed);
        AmoutOfJumpsLeft--;
        Player.InAirState.SetIsJumping();
        IsAbilityDone = true;
    }

    public bool CanJump() => AmoutOfJumpsLeft > 0;

    public void ResetAmountOfJumpsLeft() => AmoutOfJumpsLeft = PlayerData.AmountOfJumps;

    public void DecreaseAmountOfJumpsLeft() => AmoutOfJumpsLeft--;
}
