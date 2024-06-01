using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;
    protected PlayerData PlayerData;
    private string AnimName;
    protected bool IsAnimationFinished;
    protected bool IsExitingState;

    protected float StartTime { get; private set; }

    public PlayerState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData)
    {
        this.StateMachine = stateMachine;
        this.Player = player;
        this.AnimName = animName;
        this.PlayerData = playerData;
    }

    public virtual void Enter()
    {
        DoChecks();
        StartTime = Time.time;
        Player.Animator.SetBool(AnimName, true);
        IsAnimationFinished = false;
        IsExitingState = false;

        Debug.Log("Enter" + AnimName);
    }

    public virtual void Exit()
    {
        IsExitingState = true;
        Player.Animator.SetBool(AnimName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;

    public virtual void AniamtionTrigger()
    {

    }
}
