using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerStats playerStat;

    [SerializeField] PlayerData PlayerData;

    #region Comps
    
    public Rigidbody2D Rb { get; private set; }
    public Animator Animator { get; private set; }

    public BoxCollider2D Collider { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    #endregion

    #region Finite State Machine

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set ; }
    public PlayerDodgeRollState DodgeRollState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerDropDownFloor DropDownFloor { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }

    #endregion

    #region Collision Check
    public Transform GroundCheck;
    public Transform WallCheck;
    public Transform LedgeCheck;
    public Transform CeilingCheck;
    #endregion

    [SerializeField] private Transform AttackPostion;

    private Vector2 Workspace;
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    
    private void Awake()
    {
        playerStat = new PlayerStats(PlayerData.MaxHp);

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(StateMachine, this, "Idle", PlayerData);
        MoveState = new PlayerMoveState(StateMachine, this, "Move", PlayerData);
        JumpState = new PlayerJumpState(StateMachine, this, "InAir", PlayerData);
        InAirState = new PlayerInAirState(StateMachine, this, "InAir", PlayerData);
        LandState = new PlayerLandState(StateMachine, this, "Land", PlayerData);
        LedgeClimbState = new PlayerLedgeClimbState(StateMachine, this, "LedgeClimb", PlayerData);
        DodgeRollState = new PlayerDodgeRollState(StateMachine, this, "Roll", PlayerData);
        CrouchIdleState = new PlayerCrouchIdleState(StateMachine, this, "Crouch", PlayerData);
        DropDownFloor = new PlayerDropDownFloor(StateMachine, this, "InAir", PlayerData);
        WallSlideState = new PlayerWallSlideState(StateMachine, this, "WallSlide", PlayerData);
        WallGrabState = new PlayerWallGrabState(StateMachine, this, "WallGrab", PlayerData);
        WallClimbState = new PlayerWallClimbState(StateMachine, this, "WallClimb", PlayerData);
        PrimaryAttackState = new PlayerAttackState(StateMachine, this, "Attack", PlayerData, AttackPostion);
    }

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        InputHandler = GetComponent<PlayerInputHandler>();

        StateMachine.Initialize(IdleState);

        FacingDirection = 1;
    }

    private void Update()
    {
        CurrentVelocity = Rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }

    public void SetVelocityZero()
    {
        Rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocityX(float velocity)
    {
        Workspace.Set(velocity, CurrentVelocity.y);
        Rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public void SetVelocityY(float velocity)
    {
        Workspace.Set(CurrentVelocity.x, velocity);
        Rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = Collider.offset;
        Workspace.Set(Collider.size.x, height);

        center.y += (height - Collider.size.y) / 2;

        Collider.size = Workspace;
        Collider.offset = center;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    public bool IsGrounded() => Physics2D.OverlapCircle(GroundCheck.position, PlayerData.GroundCheckRadius, PlayerData.WhatIsGround) || IsOverPlatformer();
    public bool IsTouchingWall() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDirection, PlayerData.WallCheckRadius, PlayerData.WhatIsGround);
    public bool IsTouchingLedge() => Physics2D.Raycast(LedgeCheck.position, Vector2.right * FacingDirection, PlayerData.LedgeCheckRadius, PlayerData.WhatIsGround);
    public bool IsCeiling() => Physics2D.OverlapCircle(CeilingCheck.position, PlayerData.CeilingRadius, PlayerData.WhatIsGround);
    public bool IsOverPlatformer() => Physics2D.OverlapCircle(GroundCheck.position, PlayerData.GroundCheckRadius, PlayerData.WhatIsPlatformer);

    public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    public void AnimationTrigger() => StateMachine.CurrentState.AniamtionTrigger();

    public Vector2 DetermineCornerPostion()
    {
        RaycastHit2D xHit = Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDirection, PlayerData.WallCheckRadius, PlayerData.WhatIsGround);
        float xDist = xHit.distance;
        Workspace.Set(xDist * FacingDirection, 0);
        RaycastHit2D yHit = Physics2D.Raycast(LedgeCheck.position + (Vector3)Workspace, Vector2.down, LedgeCheck.position.y - WallCheck.position.y, PlayerData.WhatIsGround);
        float yDist = yHit.distance;

        Workspace.Set(WallCheck.position.x + xDist * FacingDirection, LedgeCheck.position.y - yDist);
        return Workspace;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(DetermineCornerPostion(), 0.1f);
    }
}
