using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class E_Ranger : Enemy
{
    public event Action<float> OnDamaged;

    [SerializeField] EnemyData RangerData;
    //public Rigidbody2D rb2D {  get; private set; }
    public Collider2D Collider2D { get; private set; }
    public GameObject Player {  get; private set; }

    //private int FacingDirection;
    public E_RangerIdleState                idleState           { get; private set; }
    public E_RangerPlayerDetectedState      playerDetectedState { get; private set; }
    public E_RangerDefendState              defendState         { get; private set; }
    public E_RangerDieState                 dieState            { get; private set; }
    public E_RangerDodgeState               dodgeState          { get; private set; }
    public E_RangerShootInAirState          shootInAirState     { get; private set; }
    public E_RangerHurtState                hurtState           { get; private set; }
    public E_RangerInAirState               inAirState          { get; private set; }
    public E_RangerLandState                landState           { get; private set; }
    public E_RangerMeleeAttack              meleeAttack         { get; private set; }
    public E_RangerRangedAttack             rangedAttack        { get; private set; }
    public E_RangerRollState                rollState           { get; private set; }
    public E_RangerSkillBeamAttack          beamAttack          { get; private set; }
    public E_RangerSkillFallingStarState    fallingStarState    { get; private set; }
    public E_RangerSlideState               slideState          { get; private set; }
    public E_RangerSpecialMove              specialMove         { get; private set; }
    //[SerializeField]
    //private Transform GroundCheck;
    //[SerializeField]
    //private Transform PlayerCheck;
    [SerializeField]
    private Transform AttackPostion;
    [SerializeField]
    private Transform ShootingInAirPostion;
    [SerializeField]
    private Transform MeleeAttackPostion;
    [SerializeField]
    private Transform BeamPosition;
    [SerializeField]
    private Transform DefendPostion;
    [SerializeField]
    private Transform BloodParticleEffPosition;

    public bool IsDefending { get; set; }

    public Sequencer SpecialMoveSequencer { get; private set; }
    private bool CanUseSpecialMove = true;

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override bool Damage(DamgeDetails attackDetail)
    {
        if(!IsAttackBlocked(attackDetail.ObjectAttackPosition))
        {
            base.Damage(attackDetail);

            OnDamaged?.Invoke(CurrentHp);

            GameObject.Instantiate(EnemyData.BloodParticleEff, BloodParticleEffPosition.position, transform.rotation);

            hurtState.DecreaseSR(attackDetail.Dmg);

            if (CurrentHp <= 0)
            {
                StateMachine.ChangeState(dieState);
            }
            else if(CurrentHp < EnemyData.MaxHp * 0.25f && StateMachine.CurrentState != specialMove && CanUseSpecialMove)
            {
                CanUseSpecialMove = false;
                StateMachine.ChangeState(specialMove);
            }
            return true;
        }
        GameManager.Instance.PlaySFX("Block");
        return false;
    }

    public override void KnockBack(KnockBackDetails details)
    {
        base.KnockBack(details);

        if (IsAlive() && hurtState.CanStun() && StateMachine.CurrentState != hurtState && StateMachine.CurrentState != specialMove)
        {
            //HurtState.SetFacingDirectionWhileHurt(-details.Direction);
            StateMachine.ChangeState(hurtState);

            //Vector2 force = new Vector2(details.Direction, 1f).normalized * details.Strength;
            //Rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    private bool IsAttackBlocked(Transform attackSourcePosition)
    {
        if (!IsDefending) return false;

        float PlayerToDefendPostionDistance = transform.position.x - DefendPostion.position.x;
        float AttackSourceToDefendPostionDistance = attackSourcePosition.position.x - DefendPostion.position.x;

        return PlayerToDefendPostionDistance * AttackSourceToDefendPostionDistance < 0;
    }

    private bool IsAlive()
    {
        return CurrentHp > 0;
    }

    protected override void Awake()
    {
        base.Awake();

        idleState = new E_RangerIdleState(StateMachine, this, "PlayerDetected", RangerData);
        playerDetectedState = new E_RangerPlayerDetectedState(StateMachine, this, "PlayerDetected", RangerData);
        defendState = new E_RangerDefendState(StateMachine, this, "Defend", RangerData);
        dieState = new E_RangerDieState(StateMachine, this, "Die", RangerData);
        dodgeState = new E_RangerDodgeState(StateMachine, this, "InAir", RangerData);
        shootInAirState = new E_RangerShootInAirState(StateMachine, this, "DodgeAndShoot", RangerData, ShootingInAirPostion);
        hurtState = new E_RangerHurtState(StateMachine, this, "Hurt", RangerData);
        inAirState = new E_RangerInAirState(StateMachine, this, "InAir", RangerData);
        landState = new E_RangerLandState(StateMachine, this, "Land", RangerData);
        meleeAttack = new E_RangerMeleeAttack(StateMachine, this, "MeleeAttack", RangerData, MeleeAttackPostion);
        rangedAttack = new E_RangerRangedAttack(StateMachine, this, "RangedAttack", RangerData, AttackPostion);
        rollState = new E_RangerRollState(StateMachine, this, "Roll", RangerData);
        beamAttack = new E_RangerSkillBeamAttack(StateMachine, this, "BeamAttack", RangerData, BeamPosition);
        fallingStarState = new E_RangerSkillFallingStarState(StateMachine, this, "FallingStar", RangerData);
        slideState = new E_RangerSlideState(StateMachine, this, "Slide", RangerData);
        specialMove = new E_RangerSpecialMove(StateMachine, this, "PlayerDetected", RangerData);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Start()
    {
        base.Start();

        Player = GameObject.FindGameObjectWithTag("Player");

        StateMachine.Initialize(idleState);

        SpecialMoveSequencer = GetComponent<Sequencer>();
    }


    public void PlayerDetected()
    {
        StateMachine.ChangeState(playerDetectedState);
    }
    //private void Flip()
    //{
    //    FacingDirection *= -1;
    //    transform.Rotate(0.0f, 180.0f, 0.0f);
    //}

    public void CheckIfShouldFlip()
    {
        if(FacingDirection > 0 && Player.transform.position.x < gameObject.transform.position.x
            || FacingDirection < 0 && Player.transform.position.x > gameObject.transform.position.x)
        {
            Flip();
        }
    }    

    protected override void Update()
    {
        base.Update();

        //CheckIfShouldFlip();//TODO: Recheck
    }

    public bool IsPlayerClose() => Physics2D.OverlapCircle(PlayerCheck.position, EnemyData.CloseActionDistance, EnemyData.WhatIsPlayer);
    public bool WallInfront() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDirection, EnemyData.WallCheckRadius, EnemyData.WhatIsGround);
}
