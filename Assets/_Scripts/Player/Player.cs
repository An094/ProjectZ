using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] PlayerData PlayerData;

    #region Comps
    
    public Rigidbody2D Rb { get; private set; }
    public Animator Animator { get; private set; }

    public PlayerInputHandler InputHandler { get; private set; }

    #endregion

    #region Finite State Machine

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    #endregion

    #region Collision Check
    [SerializeField] private Transform GroundCheck;
    #endregion

    private Vector2 Workspace;
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(StateMachine, this, "Idle", PlayerData);
        MoveState = new PlayerMoveState(StateMachine, this, "Move", PlayerData);
        JumpState = new PlayerJumpState(StateMachine, this, "InAir", PlayerData);
        InAirState = new PlayerInAirState(StateMachine, this, "InAir", PlayerData);
        LandState = new PlayerLandState(StateMachine, this, "Land", PlayerData);
    }

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
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

    public bool IsGrounded() => Physics2D.OverlapCircle(GroundCheck.position, PlayerData.GroundCheckRadius, PlayerData.WhatIsGround);

    public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}
