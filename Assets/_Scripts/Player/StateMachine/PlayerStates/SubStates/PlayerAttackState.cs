using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class PlayerAttackState : PlayerAbilityState
{
    private int AttackCounter;
    private float LastAttackedTime;
    int xInput;

    public PlayerAttackState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
        AttackCounter = - 1;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        LastAttackedTime = Time.time;
        IsAbilityDone = true;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        if (Time.time < LastAttackedTime + 0.2f)
        {
            return;
        }

        IsAbilityDone = false;// use this for only attack state.

        if (Time.time > LastAttackedTime + 1.5f) 
        {
            AttackCounter = 0;
        }
        else
        {
            AttackCounter = AttackCounter < 2 ? AttackCounter + 1 : 0;
        }

        Player.SetVelocityZero();

        Player.Animator.SetInteger("AttackCounter", AttackCounter);
        int attackDir = xInput != 0 ? xInput : Player.FacingDirection;
        Player.SetVelocityX(attackDir * 0.2f);
    }

    public override void Exit()
    {
        base.Exit();
       // Player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = Player.InputHandler.NormalInputX;

        //Player.CheckIfShouldFlip(xInput);
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
