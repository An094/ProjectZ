using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemy : Enemy
{
    public E_ArcherEnemyIdleState IdleState { get; private set; }
    public E_ArcherEnemyMoveState MoveState { get; private set; }
    public E_ArcherEnemyPlayerDetectedState PlayerDetectedState { get; private set; }
    public E_ArcherEnemyLookforPlayerState LookforPlayerState { get; private set; }
    public E_ArcherEnemyRangedAttackState RangedAttackState { get; private set;}
    public E_ArcherEnemyHurtState HurtState { get; private set;}
    public E_ArcherEnemyDieState DieState { get; private set; }

    [SerializeField] private Transform AttackPosition;

    protected override void Awake()
    {
        base.Awake();

        IdleState = new E_ArcherEnemyIdleState(StateMachine, this, "Idle", EnemyData);
        MoveState = new E_ArcherEnemyMoveState(StateMachine, this, "Move", EnemyData);
        PlayerDetectedState = new E_ArcherEnemyPlayerDetectedState(StateMachine, this, "PlayerDetected", EnemyData);
        LookforPlayerState = new E_ArcherEnemyLookforPlayerState(StateMachine, this, "Lookfor", EnemyData);
        RangedAttackState = new E_ArcherEnemyRangedAttackState(StateMachine, this, "RangedAttack", EnemyData, AttackPosition);
        HurtState = new E_ArcherEnemyHurtState(StateMachine, this, "Hurt", EnemyData);
        DieState = new E_ArcherEnemyDieState(StateMachine, this, "Die", EnemyData);
    }

    protected override void Start()
    {
        base.Start();

        StateMachine.Initialize(MoveState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        StateMachine.CurrentState.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public override void Damage(DamgeDetails attackDetail)
    {
        base.Damage(attackDetail);

        if (CurrentHp <= 0)
        {
            StateMachine.ChangeState(DieState);
        }
    }

    public override void KnockBack(KnockBackDetails details)
    {
        base.KnockBack(details);

        if (IsAlive())
        {
            HurtState.SetFacingDirectionWhileHurt(-details.Direction);
            StateMachine.ChangeState(HurtState);

            Vector2 force = new Vector2(details.Direction, 1f).normalized * details.Strength;
            Rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    private bool IsAlive()
    {
        return CurrentHp > 0;
    }
}
