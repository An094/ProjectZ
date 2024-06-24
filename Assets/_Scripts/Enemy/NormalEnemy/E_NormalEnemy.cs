using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NormalEnemy : Enemy
{
    public E_NormalEnemyIdleState IdleState { get; private set; }
    public E_NormalEnemyMoveState MoveState { get; private set; }
    public E_NormalEnemyPlayerDetectedState PlayerDetectedState { get; private set; }
    public E_NormalEnemyChargeState ChargeState { get; private set; }
    public E_NormalEnemyLookforPlayerState LookforPlayerState { get; private set; }
    public E_NormalEnemyMeleeAttackState MeleeAttackState { get; private set; }
    public E_NormalEnemyHurtState HurtState { get; private set; }
    public E_NormalEnemyDieState DieState { get; private set; }

    [SerializeField] private Transform AttackPostion;
    [SerializeField] private Transform BloodParticleEffPosition;

    protected override void Awake()
    {
        base.Awake();

        IdleState = new E_NormalEnemyIdleState(StateMachine, this, "Idle", EnemyData);
        MoveState = new E_NormalEnemyMoveState(StateMachine, this, "Move", EnemyData);
        PlayerDetectedState = new E_NormalEnemyPlayerDetectedState(StateMachine, this, "PlayerDetected", EnemyData);
        ChargeState = new E_NormalEnemyChargeState(StateMachine, this, "Charge", EnemyData);
        LookforPlayerState = new E_NormalEnemyLookforPlayerState(StateMachine, this, "Lookfor", EnemyData);
        MeleeAttackState = new E_NormalEnemyMeleeAttackState(StateMachine, this, "MeleeAttack", EnemyData, AttackPostion);
        HurtState = new E_NormalEnemyHurtState(StateMachine, this, "Hurt", EnemyData);
        DieState = new E_NormalEnemyDieState(StateMachine, this, "Die", EnemyData);
    }

    protected override void Start()
    {
        base.Start();

        StateMachine.Initialize(MoveState);
        //FacingDirection = -1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();

    }

    public override bool Damage(DamgeDetails attackDetail)
    {
        base.Damage(attackDetail);

        GameObject.Instantiate(EnemyData.BloodParticleEff, BloodParticleEffPosition.position, transform.rotation);

        if (CurrentHp <= 0)
        {
            StateMachine.ChangeState(DieState);
        }
        return true;
    }

    public override void KnockBack(KnockBackDetails details)
    {
        base.KnockBack(details);

        if(IsAlive())
        {
            //HurtState.SetFacingDirectionWhileHurt(-details.Direction);
            StateMachine.ChangeState(HurtState);

            Vector2 force = new Vector2(details.Direction, 1f).normalized * details.Strength;
            Rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    private bool IsAlive()
    {
        return CurrentHp > 0;
    }
}
