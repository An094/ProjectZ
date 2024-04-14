using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float MovementSpeed = 10f;

    [Header("Jump State")]
    public float JumpSpeed = 15f;
    public int AmountOfJumps = 2;

    [Header("In Air State")]
    public float CoyoteTime = 0.2f;
    public float VariableJumpHeightMultiplier = 0.5f;

    [Header("Collision Check")]
    public float GroundCheckRadius = 0.2f;
    public LayerMask WhatIsGround;
}
