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

    [SerializeField] private Transform AttackPostion;
    protected override void Awake()
    {
        base.Awake();

        IdleState = new E_NormalEnemyIdleState(StateMachine, this, "Idle", EnemyData);
        MoveState = new E_NormalEnemyMoveState(StateMachine, this, "Move", EnemyData);
        PlayerDetectedState = new E_NormalEnemyPlayerDetectedState(StateMachine, this, "PlayerDetected", EnemyData);
        ChargeState = new E_NormalEnemyChargeState(StateMachine, this, "Charge", EnemyData);
        LookforPlayerState = new E_NormalEnemyLookforPlayerState(StateMachine, this, "Lookfor", EnemyData);
        MeleeAttackState = new E_NormalEnemyMeleeAttackState(StateMachine, this, "MeleeAttack", EnemyData, AttackPostion);
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
}
