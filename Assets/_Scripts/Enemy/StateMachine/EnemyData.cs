using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Idle state")]
    public float idleTime = 1.0f;

    [Header("Move state")]
    public float moveSpeed = 1.0f;

    [Header("Player Detected state")]
    public float MinAgroDistance = 3f;
    public float MaxAgroDistance = 4f;

    [Header("Check variables")]
    public float GroundCheckRadius = 0.2f;
    public float WallCheckRadius = 0.5f;
    public float LedgeCheckRadius = 0.5f;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsPlayer;
}
