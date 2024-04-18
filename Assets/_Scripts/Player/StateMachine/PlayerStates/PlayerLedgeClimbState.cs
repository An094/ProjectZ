using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 DetectedPos;
    private Vector2 CornerPos;
    private Vector2 StartPos;
    private Vector2 StopPos;
    private Vector2 Workspace;

    public PlayerLedgeClimbState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData) : base(stateMachine, player, animName, playerData)
    {
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

        Player.SetVelocityZero();
        Player.transform.position = DetectedPos;
        CornerPos = DetermineCornerPostion();

        StartPos.Set(CornerPos.x - (Player.FacingDirection * PlayerData.StartOffset.x), CornerPos.y - PlayerData.StartOffset.y);
        StopPos.Set(CornerPos.x + (Player.FacingDirection * PlayerData.StopOffset.x), CornerPos.y + PlayerData.StopOffset.y);
    
        Player.transform.position = StartPos;
    }

    public override void Exit()
    {
        base.Exit();

        Player.transform.position = StopPos;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(IsAnimationFinished)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
        else
        {
            Player.transform.position = StartPos;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void SetDetectedPos(Vector2 pos) => DetectedPos = pos;

    public Vector2 DetermineCornerPostion()
    {
        RaycastHit2D xHit = Physics2D.Raycast(Player.WallCheck.position, Vector2.right * Player.FacingDirection, PlayerData.WallCheckRadius, PlayerData.WhatIsGround);
        float xDist = xHit.distance;
        Workspace.Set(xDist * Player.FacingDirection, 0);
        RaycastHit2D yHit = Physics2D.Raycast(Player.LedgeCheck.position + (Vector3)Workspace, Vector2.down, Mathf.Abs(Player.LedgeCheck.position.y - Player.WallCheck.position.y) + 0.1f, PlayerData.WhatIsGround);
        float yDist = yHit.distance;

        Workspace.Set(Player.WallCheck.position.x + xDist * Player.FacingDirection, Player.LedgeCheck.position.y - yDist);
        Debug.Log("CornerPosition: " + Workspace + "yDist: " + yDist);
        return Workspace;
    }
}
