using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnAround : PlayerGroundedState
{
    const float TimeTillZeroVelocity = 0.15f;
    bool HasRotated = false;
    public PlayerTurnAround(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void AniamtionTrigger()
    {
        base.AniamtionTrigger();
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
        HasRotated = false;
    }

    public override void Exit()
    {
        base.Exit();

        Player.Flip();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Player.SetVelocityY(0);

        if(!IsAnimationFinished)
        {
            if (Time.time < StartTime + TimeTillZeroVelocity)
            {
                Player.SetVelocityX(Mathf.Lerp(Player.CurrentVelocity.x, - PlayerData.MovementSpeed * Player.FacingDirection * 0.5f, TimeTillZeroVelocity));
            }
            else
            {
                //if(!HasRotated)
                //{
                //    HasRotated = true;
                //    Player.SetVelocityX(0);
                //}
                Player.SetVelocityX(Mathf.Lerp(Player.CurrentVelocity.x, -PlayerData.MovementSpeed * Player.FacingDirection, TimeTillZeroVelocity));
            }
        }
        else
        {
            if(xInput != 0)
            {
                StateMachine.ChangeState(Player.MoveState);
            }
            else
            {
                StateMachine.ChangeState(Player.IdleState);
            }
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
