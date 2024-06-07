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
    public float longRangeActionTime = 0.5f;

    [Header("Charge state")]
    public float ChargeSpeed = 3.0f;
    public float ChargeTime = 2.0f;

    [Header("Look for state")]
    public float TimeBetweenTurns = 0.75f;
    public int AmountOfTurns = 2;

    [Header("Hurt state")]
    public float StunTime = 0.2f;

    [Header("Dodge state")]
    public float DodgeSpeed = 5.0f;
    public Vector2 DodgeAngle = Vector2.one;
    public float DodgeTime = 1f;

    [Header("Melee attack state")]
    public float AttackRadius = 0.5f;
    public float AttackDamage = 10f;

    [Header("Ranged State")]
    public GameObject ProjectilePref;
    public float TravelDistance = 5.0f;
    public float ProjectileSpeed = 10.0f;
    public float ProjectileDamage = 50.0f;

    [Header("Check variables")]
    public float GroundCheckRadius = 0.2f;
    public float WallCheckRadius = 0.5f;
    public float LedgeCheckRadius = 0.5f;
    public float CloseRangeActionDistance = 2.0f;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsPlayer;

    [Header("Stats")]
    public float MaxHp = 100.0f;

    [Header("Explosion")]
    public bool IsTriggerExplositionAfterDead = false;
    public GameObject Explosion;
    public float ExplosionRadius = 1f;

    [Header("BOSS")]
    public float CloseActionDistance = 2.0f;

    public float FallingStarCooldown = 20.0f;
    public float BeamAttackCooldown = 10.0f;

    public float DodgeAndShootCooldown = 20.0f;
    public float DodgeCooldown = 15.0f;
    public float RollCooldown = 10.0f;
    public float SlideCooldown = 5.0f;
    public float DefendCooldown = 2.5f;

}
