using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropDownFloor : PlayerState
{
    private bool IsGrounded;
    private bool IsCeiling;
    private bool IsOverPlatformer;
    public PlayerDropDownFloor(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsGrounded = Player.IsGrounded();
        IsCeiling = Player.IsCeiling();
        IsOverPlatformer = Player.IsOverPlatformer();
    }

    public override void Enter()
    {
        base.Enter();

        Player.Collider.enabled = false;

        Player.StartCoroutine(FinishState());
    }

    public override void Exit()
    {
        base.Exit();

        Player.Collider.enabled = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //if (IsGrounded)
        //{
        //    StateMachine.ChangeState(Player.LandState);
        //}
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    IEnumerator FinishState()
    {
        yield return new WaitForSeconds(0.2f);
        StateMachine.ChangeState(Player.InAirState);
    }
}
