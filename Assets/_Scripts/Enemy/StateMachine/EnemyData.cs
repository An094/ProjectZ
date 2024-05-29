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
    public float longRangeActionTime = 1.5f;

    [Header("Charge state")]
    public float ChargeSpeed = 3.0f;
    public float ChargeTime = 2.0f;

    [Header("Look for state")]
    public float TimeBetweenTurns = 0.75f;
    public int AmountOfTurns = 2;

    [Header("Melee attack state")]
    public float AttackRadius = 0.5f;
    public float AttackDamage = 10f;

    [Header("Hurt state")]
    public float StunTime = 0.2f;

    [Header("Check variables")]
    public float GroundCheckRadius = 0.2f;
    public float WallCheckRadius = 0.5f;
    public float LedgeCheckRadius = 0.5f;
    public float CloseRangeActionDistance = 2.0f;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsPlayer;

    [Header("Stats")]
    public float MaxHp = 100.0f;
}
