using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerGroundedState
{
    int StepCounter = 1;
    bool IsExiting = false;
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

        IsExiting = false;
        Player.StartCoroutine(PlayerStepSound());

    }

    public override void Exit()
    {
        base.Exit();
        IsExiting = true;
        Player.StopAllCoroutines();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Player.CheckIfShouldFlip(xInput);

        if(!IsExitingState)
        {
            if (xInput == 0)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
            else
            {
                if(xInput == Player.FacingDirection)
                {
                    Player.SetVelocityX(PlayerData.MovementSpeed * xInput);
                }
                else
                {
                    StateMachine.ChangeState(Player.TurnAround);
                }
            }
        }
       
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    IEnumerator PlayerStepSound()
    {
        while (!IsExiting)
        {
            StepCounter = StepCounter >= 6 ? 1 : StepCounter + 1;
            GameManager.Instance.PlayerMoveSFX(StepCounter);
            yield return new WaitForSeconds(0.4f);
        }

    }
}
