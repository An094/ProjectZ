using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public float StandColliderHeight = 1.19f;

    [Header("Move State")]
    public float MovementSpeed = 10f;

    [Header("Jump State")]
    public float JumpSpeed = 15f;
    public int AmountOfJumps = 2;

    [Header("In Air State")]
    public float CoyoteTime = 0.2f;
    public float VariableJumpHeightMultiplier = 0.5f;

    [Header("Wall Slide State")]
    public float WallSlideVelocity = 2f;

    [Header("Ledge Climb State")]
    public Vector2 StartOffset;
    public Vector2 StopOffset;

    [Header("Roll State")]
    public float GroundRollVelocity = 15;
    public float InAirRollVelocity = 7;
    public float RollVelocityY = 1;
    public float RollingCooldown = 1f;
    public float RollingColliderHeight = 0.7f;

    [Header("Crouch State")]
    public float CrouchColliderHeight = 0.7f;

    [Header("Check Variables")]
    public float GroundCheckRadius = 0.2f;
    public float WallCheckRadius = 0.5f;
    public float LedgeCheckRadius = 0.5f;
    public LayerMask WhatIsGround;
}
